import { Usuario } from './usuario.entity';
import { map } from 'rxjs/operators';
import { Observable } from 'rxjs';
import { Component, OnInit, ViewChild, ElementRef } from '@angular/core';
import { PerfisDeAcessoDisponiveis, TextoDosPerfisDeAcessoDisponiveis } from '../perfis-de-acesso/perfis-de-acesso-disponiveis';
import { UsuarioService } from './usuario.service';
import { Router, ActivatedRoute } from '@angular/router';
import { debug } from 'util';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  @ViewChild('email', { static: false }) emailElement: ElementRef;

  idDoUsuarioSelecionado;
  mensagensDeErro: any[];
  gravadoComSucesso: boolean = false;
  mostrarErros: boolean = false;
  perfisDisponiveis = [];
  usuarioEmEdicao: Usuario = new Usuario();
  constructor(private router: Router, private usuarioService: UsuarioService, private route: ActivatedRoute) { }

  ngOnInit() {

    this.route.paramMap.pipe(
      map(p => p.get('id'))
    ).subscribe(
      (id) => {

        TextoDosPerfisDeAcessoDisponiveis.forEach((value: string, key: number) => {
          this.perfisDisponiveis.push({ nome: value, valor: PerfisDeAcessoDisponiveis[key], selecionado: false });
        });

        if (id) {

          this.usuarioService.obter(id).subscribe((usuarioObtido: Usuario) => {
            this.idDoUsuarioSelecionado = id;
            this.usuarioEmEdicao = usuarioObtido;

            this.perfisDisponiveis.forEach(perfil => {
              let perfilExistente = false;
              usuarioObtido.perfis.forEach(perfilDoUsuario => {
                if (perfilDoUsuario === perfil.valor) {
                  perfilExistente = true;
                }
              });
              if (perfilExistente) {
                perfil.selecionado = true;
              }
            });
          });
        }
      }
    );


  }

  gravar(formulario) {

    this.gravadoComSucesso = false;
    this.mostrarErros = false;
    this.mensagensDeErro = [];

    this.usuarioEmEdicao['perfis'] = [];

    this.perfisDisponiveis.forEach(element => {
      if (element.selecionado) {
        this.usuarioEmEdicao['perfis'].push(element.valor);
      }
    });

    if (!this.idDoUsuarioSelecionado) {
      if (this.usuarioEmEdicao.senha !== this.usuarioEmEdicao.confirmacaoDeSenha) {
        this.mostrarErros = true;
        this.mensagensDeErro.push({ errorMessage: 'Confirmação de senha incorreta' });
        console.log(this.mensagensDeErro);
        return;
      }

      this.usuarioService.criarNovo(this.usuarioEmEdicao)
        .subscribe(
          result => {
            if (result) {
              this.gravadoComSucesso = true;
              formulario.reset();
              this.emailElement.nativeElement.focus();
            }
          },
          error => {
            this.mostrarErros = true;
            console.log(error);
            this.mensagensDeErro = error;
          }
        );
    }
    else {
      this.usuarioEmEdicao["id"] = this.idDoUsuarioSelecionado;
      this.usuarioService.alterar(this.usuarioEmEdicao)
        .subscribe(
          result => {
            if (result) {
              this.router.navigate(['/controle-de-acesso/usuarios']);
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

  excluir(formulario) {

    this.gravadoComSucesso = false;
    this.mostrarErros = false;
    this.mensagensDeErro = [];

    if (this.idDoUsuarioSelecionado) {
      this.usuarioService.excluir(this.idDoUsuarioSelecionado)
        .subscribe(
          result => {
            if (result) {
              this.router.navigate(['/controle-de-acesso/usuarios']);
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
}
