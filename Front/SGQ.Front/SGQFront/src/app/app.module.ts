import { PerfisDeAcessoDisponiveis, TextoDosPerfisDeAcessoDisponiveis } from './controle-de-acesso/perfis-de-acesso/perfis-de-acesso-disponiveis';
import { AuthGuard } from './controle-de-acesso/servicos/auth-guard.service';
import { DefinicaoDeUrlsDeApis } from './definicao-de-urls-de-apis';
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
import { UsuarioService } from './controle-de-acesso/usuario/usuario.service';
import { UsuariosService } from './controle-de-acesso/usuarios/usuarios.service';
import { SemAcessoComponent } from './controle-de-acesso/erros/sem-acesso/sem-acesso.component';
import { PerfilAuthGuard } from './controle-de-acesso/servicos/perfil-auth-guard.service';


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
    NormaOuControleComponent,
    SemAcessoComponent
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

      {
        path: 'controle-de-acesso/usuarios/novo', component: UsuarioComponent,
        canActivate: [AuthGuard, PerfilAuthGuard], data: {
          perfil: PerfisDeAcessoDisponiveis[PerfisDeAcessoDisponiveis.AdministradorDoControleDeAcesso]
        }
      },
      {
        path: 'controle-de-acesso/usuarios/:id', component: UsuarioComponent,
        canActivate: [AuthGuard, PerfilAuthGuard], data: {
          perfil: PerfisDeAcessoDisponiveis[PerfisDeAcessoDisponiveis.AdministradorDoControleDeAcesso]
        }
      },
      {
        path: 'controle-de-acesso/usuarios', component: UsuariosComponent,
        canActivate: [AuthGuard, PerfilAuthGuard], data: {
          perfil: PerfisDeAcessoDisponiveis[PerfisDeAcessoDisponiveis.AdministradorDoControleDeAcesso]
        }
      },

      {
        path: 'processos/pecas/novo', component: PecaComponent,
        canActivate: [AuthGuard, PerfilAuthGuard], data: {
          perfil: PerfisDeAcessoDisponiveis[PerfisDeAcessoDisponiveis.AdministradorDeProcessos]
        }
      },
      {
        path: 'processos/pecas/:id', component: PecaComponent,
        canActivate: [AuthGuard, PerfilAuthGuard], data: {
          perfil: PerfisDeAcessoDisponiveis[PerfisDeAcessoDisponiveis.AdministradorDeProcessos]
        }
      },
      {
        path: 'processos/pecas', component: PecasComponent,
        canActivate: [AuthGuard, PerfilAuthGuard], data: {
          perfil: PerfisDeAcessoDisponiveis[PerfisDeAcessoDisponiveis.AdministradorDeProcessos]
        }
      },

      { path: 'sem-acesso', component: SemAcessoComponent }
    ])
  ],
  providers: [
    AutenticacaoService,
    DefinicaoDeUrlsDeApis,
    UsuarioService,
    UsuariosService,
    AuthGuard
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
