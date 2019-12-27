import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmpresaService } from '../services/empresa.service';
import { EmpresaDTO } from '../models/empresa';


@Component({
  selector: 'app-empresa',
  templateUrl: './empresa.component.html',
  styleUrls: ['./empresa.component.css']
})
export class EmpresaComponent implements OnInit {
    empresaForm: FormGroup;
    loading = false;
    submitted = false;
    error = '';
  
  constructor(
    private formBuilder: FormBuilder,
    private empresaservice : EmpresaService) {
  }


  ngOnInit() {
    this.empresaForm = this.formBuilder.group({
      NomeEmpresa : ['', Validators.required],
      CNPJ : ['', Validators.required],
      NomeUsuario : ['', Validators.required],
      Senha : ['', Validators.required]
    });


  }

  empresa: EmpresaDTO;

  onSubmit() {
    this.submitted = true;

    const empresa = this.empresaForm.value;

    // stop here if form is invalid
    if (this.empresaForm.invalid) {
      return;
    }

    this.insertEmpresa(empresa);

    this.loading = true;
    
  }

  insertEmpresa(empresa:EmpresaDTO){

    this.empresaservice.addEmpresa(empresa);

  }


}
