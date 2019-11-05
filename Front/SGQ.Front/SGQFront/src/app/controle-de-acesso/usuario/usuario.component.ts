import { Component, OnInit } from '@angular/core';
import { PerfisDeAcessoDisponiveis, TextoDosPerfisDeAcessoDisponiveis } from '../perfis-de-acesso/perfis-de-acesso-disponiveis';
import { UsuarioService } from './usuario.service';
import { Router } from '@angular/router';
import { debug } from 'util';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  mensagensDeErro: any[];
  gravadoComSucesso: boolean = false;
  mostrarErros: boolean = false;
  perfisDisponiveis = [];

  constructor(private router: Router, private usuarioService: UsuarioService) { }

  ngOnInit() {

    TextoDosPerfisDeAcessoDisponiveis.forEach((value: string, key: number) => {
      this.perfisDisponiveis.push({ nome: value, valor: PerfisDeAcessoDisponiveis[key], selecionado: false });
    });
  }

  gravar(usuario, formulario) {
    this.gravadoComSucesso = false;
    this.mostrarErros = false;
    this.mensagensDeErro = [];

    usuario['perfis'] = [];

    this.perfisDisponiveis.forEach(element => {
      if (element.selecionado) {
        usuario['perfis'].push(element.valor);
      }
    });

    this.usuarioService.criarNovo(usuario)
      .subscribe(
        result => {
          if (result) {
            this.gravadoComSucesso = true;
            formulario.reset();
          }
        },
        error => {
          this.mostrarErros = true;
          console.log(error);
          this.mensagensDeErro = error;
        }
      );
  }

}
