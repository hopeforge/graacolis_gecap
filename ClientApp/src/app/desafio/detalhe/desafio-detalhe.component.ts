import { Component, OnInit } from '@angular/core';
import { DesafioDTO } from 'src/app/models';

@Component({
  selector: 'app-desafio-detalhe',
  templateUrl: './desafio-detalhe.component.html',
  styleUrls: ['./desafio-detalhe.component.css']
})
export class DesafioDetalheComponent implements OnInit {
  desafio: DesafioDTO;
  constructor() {

  }

  ngOnInit() {
    console.log(history.state);
    this.desafio = history.state.data;
  }

  

}
