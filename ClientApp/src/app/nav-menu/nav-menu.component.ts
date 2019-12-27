import { Component, HostBinding } from '@angular/core';
import { AuthenticationService } from '../services';
import { Router } from '@angular/router';
import { EmitterService } from '../services/emitter.service';
import { BsDropdownConfig } from 'ngx-bootstrap/dropdown';

@Component({
  selector: 'app-nav-menu',
  templateUrl: './nav-menu.component.html',
  styleUrls: ['./nav-menu.component.css'],
  providers: [{ provide: BsDropdownConfig, useValue: { isAnimated: true, autoClose: true } }]
})
export class NavMenuComponent {
  isExpanded = false;
  isLogged = false;
  isCollapsed = true;

  constructor(
    private emitter: EmitterService,
    private auth: AuthenticationService,
    private router: Router) {
    if (this.auth.currentUserValue)
      this.isLogged = true;
    this.emitter.valueEmitter
      .subscribe(val => { this.isLogged = val });
  }
  collapse() {
    this.isExpanded = false;
  }

  toggle() {
    this.isExpanded = !this.isExpanded;
  }

  logout() {
    this.auth.logout();
    this.isLogged = false;
    this.router.navigate(['/login']);
  }


}
