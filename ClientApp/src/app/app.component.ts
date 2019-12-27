import { Component } from '@angular/core';
import { User } from './models';
import { Router } from '@angular/router';
import { AuthenticationService } from './services';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})
export class AppComponent {
  currentUser: User;

    constructor(
        private router: Router,
        private authenticationService: AuthenticationService
    ) {
        this.authenticationService.currentUser
        .subscribe(user => this.currentUser = user);
    }

    logout() {
        this.authenticationService.logout();
        this.router.navigate(['/login']);
    }
}
