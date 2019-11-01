import { AutenticacaoService } from './controle-de-acesso/servicos/autenticacao.service';
import { RouterModule } from '@angular/router';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BsNavbarComponent } from './bs-navbar/bs-navbar.component';
import { HomeComponent } from './home/home.component';
import { PecasComponent } from './processos/pecas/pecas.component';
import { PecaComponent } from './processos/peca/peca.component';
import { UsuariosComponent } from './controle-de-acesso/usuarios/usuarios.component';
import { UsuarioComponent } from './controle-de-acesso/usuario/usuario.component';
import { LoginComponent } from './controle-de-acesso/login/login.component';
import { NormaOuControleComponent } from './compliance/norma-ou-controle/norma-ou-controle.component';
import { FormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    BsNavbarComponent,
    HomeComponent,
    PecasComponent,
    PecaComponent,
    UsuariosComponent,
    UsuarioComponent,
    LoginComponent,
    NormaOuControleComponent
  ],
  imports: [
    BrowserModule,
    //AppRoutingModule
    NgbModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent },
      { path: 'login', component: LoginComponent },      
      { path: 'controle-de-acesso/usuarios/novo', component: UsuarioComponent },
      { path: 'controle-de-acesso/usuarios/:id', component: UsuarioComponent },
      { path: 'controle-de-acesso/usuarios', component: UsuariosComponent },
      /*{ path: 'controle-de-acesso/usuario', component: UsuarioComponent },      */
      { path: 'processos/pecas', component: PecasComponent },
      /*{ path: 'processos/peca', component: PecaComponent },*/
    ])
  ],
  providers: [
    AutenticacaoService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
