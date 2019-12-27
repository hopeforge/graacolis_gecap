import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {  ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { JwtInterceptor, ErrorInterceptor } from './helpers';
import { FormsModule } from '@angular/forms';
import { DesafioService } from './services/desafio.service';
import { appRoutingModule } from './app.routing';
import { BsDropdownModule, CollapseModule } from 'ngx-bootstrap';
import { DesafioListagemComponent } from './desafio/listagem/desafio-listagem.component';
import { DesafioCadastroComponent } from './desafio/cadastro/desafio-cadastro.component';
import { EmpresaComponent } from './empresa/empresa.component';
import { LoginComponent } from './login/login.component';
import { DesafioProgramadoComponent } from './desafio-programado/list/desafio-programado.component';
import { DesafioProgramadoDetailComponent } from './desafio-programado/detail/desafio-programado-detail.component';
import { DesafioDetalheComponent } from './desafio/detalhe/desafio-detalhe.component';
import { AngularFontAwesomeModule } from 'angular-font-awesome';
import {NgxChartsModule} from '@swimlane/ngx-charts';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    CounterComponent,
    LoginComponent,
    DesafioCadastroComponent,
    DesafioListagemComponent,
    EmpresaComponent,
    DesafioProgramadoComponent,
    DesafioProgramadoDetailComponent,
    DesafioDetalheComponent,
    EmpresaComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    ReactiveFormsModule,
    FormsModule,
    appRoutingModule,
    BsDropdownModule.forRoot(),
    CollapseModule.forRoot(),
    AngularFontAwesomeModule,
    NgxChartsModule
  ],
  exports :[DesafioListagemComponent],
  providers: [
    { provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi: true },
        { provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi: true },
        DesafioService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
