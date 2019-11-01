import { AutenticacaoService } from './../controle-de-acesso/servicos/autenticacao.service';
import { Component, OnInit } from '@angular/core';
import { Router } from "@angular/router";
import { PerfisDeAcessoDisponiveis, TextoDosPerfisDeAcessoDisponiveis } from '../controle-de-acesso/perfis-de-acesso/perfis-de-acesso-disponiveis';

@Component({
  selector: 'bs-navbar',
  templateUrl: './bs-navbar.component.html',
  styleUrls: ['./bs-navbar.component.css']
})
export class BsNavbarComponent implements OnInit {

  constructor(private servicoDeAutenticacao: AutenticacaoService,
    public router: Router) { }

  ngOnInit() {
  }

  public mostrarMenuResponsivo: boolean = false;

  public get usuarioEstaLogado() : boolean {
    return this.servicoDeAutenticacao.usuarioEstaLogado;
  }

  public usuarioPossuiPerfil(perfil){
    return this.servicoDeAutenticacao.usuarioLogadoPossuiPerfil(PerfisDeAcessoDisponiveis[perfil]);
  }

  
  public toggleMenuResponsivo(){
    this.mostrarMenuResponsivo = !this.mostrarMenuResponsivo;
  }

  public logout(){
    this.servicoDeAutenticacao.logout();
    this.router.navigate(['/']);
  }

  public get nomeDoUsuarioLogado(){
    var usuarioLogado = this.servicoDeAutenticacao.usuarioLogado;
    if(!usuarioLogado)  return null;
    return usuarioLogado.Nome;
  }

  public get PerfisDeAcessoDisponiveis(){
    return PerfisDeAcessoDisponiveis;
  }

}
