import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DesafioDTO } from '../models/desafio';
import { Observable } from 'rxjs'; 

@Injectable({
  providedIn: 'root'
})
export class DesafioService {

  uri = 'http://localhost:5000/v1/desafio';

  constructor(private http: HttpClient) { }

  addDesafio(desafio:DesafioDTO){

    console.log(desafio);

   return this.http.post<DesafioDTO>(this.uri+'/add',desafio)
      .subscribe(res => console.log('Done'));
  }


  listarTodos(){
    return this.http.get<DesafioDTO[]>(this.uri+'/getList');
  }


}
