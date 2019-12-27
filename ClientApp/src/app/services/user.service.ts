import { Injectable } from '@angular/core';
import { User } from '../models';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http:HttpClient) { }

  getAll(){
    return this.http.get<User[]>(`${environment.apiUrl}/users`);
  }
}
