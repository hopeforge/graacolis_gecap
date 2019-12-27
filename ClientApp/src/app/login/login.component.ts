import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../services';
import { first } from 'rxjs/operators';
import { EmitterService } from '../services/emitter.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private emitter: EmitterService,
    private authenticationService: AuthenticationService) {

    if (this.authenticationService.currentUserValue)
      this.navigateToHome();
  }
  private navigateToHome() {
    this.router.navigate(['/']);
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      username: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  private getReturnURL(): string {
    return this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  get f() { return this.loginForm.controls; }

  async onSubmit() {
    this.submitted = true;

    // stop here if form is invalid
    if (this.loginForm.invalid) {
      return;
    }

    this.loading = true;
    await this.authenticationService.login(this.f.username.value, this.f.password.value)
      .then(response => response
        .subscribe(
          () => {
            this.emitter.valueEmitter.emit(true);
            this.router.navigate([this.getReturnURL()]);
          },
          error => {
            this.error = error;
            this.loading = false;
          })
      );
  }
}
