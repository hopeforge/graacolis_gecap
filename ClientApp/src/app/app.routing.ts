import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CounterComponent } from './counter/counter.component';
import { LoginComponent } from './login/login.component';
import { AuthGuard } from './services';
import { DesafioCadastroComponent} from './desafio/cadastro'
import { DesafioListagemComponent } from './desafio/listagem/desafio-listagem.component';
import { EmpresaComponent } from './empresa/empresa.component';
import { DesafioProgramadoComponent } from './desafio-programado/list/desafio-programado.component';
import { DesafioProgramadoDetailComponent } from './desafio-programado/detail/desafio-programado-detail.component';
import { DesafioDetalheComponent } from './desafio/detalhe/desafio-detalhe.component';


const routes: Routes = [
    { path: '', component: HomeComponent, pathMatch: 'full', canActivate: [AuthGuard] },
    { path: 'desafio', component: DesafioListagemComponent, canActivate: [AuthGuard] },
    { path: 'desafio/detalhe', component: DesafioDetalheComponent, canActivate: [AuthGuard] },
    { path: 'cadastro/desafio', component: DesafioCadastroComponent, canActivate: [AuthGuard] },
    { path: 'cadastro/empresa', component: EmpresaComponent, canActivate: [AuthGuard] },
    { path: 'desafio-programado', component: DesafioProgramadoComponent, canActivate: [AuthGuard] },
    { path: 'desafio-programado/detalhe', component: DesafioProgramadoDetailComponent, canActivate: [AuthGuard] },
    { path: 'login', component: LoginComponent },
    { path: '**', redirectTo: '' },
  ];

export const appRoutingModule = RouterModule.forRoot(routes);