import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DesafioDTO } from '../models/desafio';
import { Observable } from 'rxjs'; 
import { EmpresaDTO } from '../models/empresa';


@Injectable({
  providedIn: 'root'
})
export class EmpresaService {

  uri = 'http://localhost:5000/v1/empresa';

  constructor(private http: HttpClient) { }

  addEmpresa(empresa:EmpresaDTO){

    console.log(empresa);

   return this.http.post<DesafioDTO>(this.uri+'/add',empresa)
      .subscribe(res => console.log('Done'));
  }

}
