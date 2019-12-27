import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { AuthenticationService } from '../../services';
import { first } from 'rxjs/operators';
import { DesafioDTO } from '../../models/desafio';
import {DesafioService} from '../../services/desafio.service';


@Component({
  selector: 'app-desafio-cadastro-component',
  templateUrl: './desafio-cadastro.component.html',
  styleUrls: ['./desafio-cadastro.component.css']
})
export class DesafioCadastroComponent implements OnInit {
  desafioForm: FormGroup;
  loading = false;
  submitted = false;
  returnUrl: string;
  error = '';

  constructor(
    private formBuilder: FormBuilder,
    private desafioservice : DesafioService) {
  }

  ngOnInit() {
    this.desafioForm = this.formBuilder.group({
      NomeDesafio: ['', Validators.required],
      Descricao: ['', Validators.required],
      Etapas: ['', Validators.required],
      DataInicio: ['', Validators.required],
      DataFinal:  ['', Validators.required],
      Tipo:  ['', Validators.required],
      QuantidadePremiados:  ['', Validators.required],
    });

  }
  desafio: DesafioDTO;

  onSubmit() {
    this.submitted = true;

    const desafio = this.desafioForm.value;

    // stop here if form is invalid
    if (this.desafioForm.invalid) {
      return;
    }

    this.insertDesafio(desafio);

    this.loading = true;
    
  }

  insertDesafio(desafio:DesafioDTO){

    this.desafioservice.addDesafio(desafio);

  }

}
