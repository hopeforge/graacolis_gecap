import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { DesafioService } from '../../services/desafio.service';
import { DesafioDTO } from 'src/app/models';
import { Router } from '@angular/router';

@Component({
  selector: 'app-desafio-listagem',
  encapsulation: ViewEncapsulation.None,
  templateUrl: './desafio-listagem.component.html',
  styleUrls: ['./desafio-listagem.component.css']
})
export class DesafioListagemComponent implements OnInit {
  desafio: DesafioDTO;

  constructor(private router: Router, private desafioservice: DesafioService) { 
    this.desafio = new DesafioDTO();
    this.desafio.descricao = "descrição de exemplo";
    this.desafio.etapas="Etapas a seguir";
    this.desafio.dataInicio = new Date('12/10/2019').toDateString();
    this.desafio.dataFinal =  new Date('01/10/2020').toDateString();
    this.desafio.nomeDesafio = "Exemplo de nome";
    this.desafio.tipo = "Tipo de desafio";
    this.desafio.quantidadePremiados = 2;
  }

  ngOnInit() {
      this.GetAllDesafios();
  }

  DesafioList:DesafioDTO[];


  GetAllDesafios() {

    this.desafioservice.listarTodos().subscribe(data =>{this.DesafioList = data;});
    
  }




}
