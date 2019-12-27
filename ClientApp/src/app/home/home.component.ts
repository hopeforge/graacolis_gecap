import { Component, OnInit } from '@angular/core';
import { UserService } from '../services';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {
  loading: boolean = false;
  constructor(private userService: UserService){}

  ngOnInit(){
    this.loading = true;
    this.userService.getAll();
  }
}
