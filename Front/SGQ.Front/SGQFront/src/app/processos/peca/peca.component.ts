import { NormaOuControleComponent } from './../../compliance/norma-ou-controle/norma-ou-controle.component';
import { Peca } from './peca.entity';
import { Component, OnInit, ElementRef, ViewChild } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { PecaService } from './peca.service';
import { map } from 'rxjs/operators';

@Component({
  selector: 'app-peca',
  templateUrl: './peca.component.html',
  styleUrls: ['./peca.component.css']
})
export class PecaComponent implements OnInit {

  @ViewChild('nome', { static: false }) nomeElement: ElementRef;
  @ViewChild('normaoucontrole', { static: false }) normaOuControleElement: NormaOuControleComponent;
  mensagensDeErro: any[];
  gravadoComSucesso: boolean = false;
  mostrarErros: boolean = false;
  pecaEmEdicao: Peca = new Peca();
  constructor(private router: Router, private pecaService: PecaService, private route: ActivatedRoute) { }
  idDaPecaSelecionada;
  ngOnInit() {

    this.route.paramMap.pipe(
      map(p => p.get('id'))
    ).subscribe(

      (id) => {

        if (id) {

          this.pecaService.obter(id).subscribe((pecaObtida: Peca) => {

            this.idDaPecaSelecionada = id;
            this.pecaEmEdicao = pecaObtida;

          });
        }
      }
    );

  }
  gravar(formulario) {

    this.gravadoComSucesso = false;
    this.mostrarErros = false;
    this.mensagensDeErro = [];
    this.pecaEmEdicao.normasEControlesRelacionados = [];
    this.normaOuControleElement.normasSelecionadas.forEach(normaSelecionada => {
      this.pecaEmEdicao.normasEControlesRelacionados.push(
        { IdentificadorDaNormaOuControle: normaSelecionada }
      );
    });

    if (!this.idDaPecaSelecionada) {


      this.pecaService.criarNova(this.pecaEmEdicao)
        .subscribe(
          result => {
            if (result) {
              this.gravadoComSucesso = true;
              formulario.reset();
              this.pecaEmEdicao = new Peca();
              this.normaOuControleElement.normas.forEach(normaSelecionada => {
                normaSelecionada.selecionado = false;
              });
              this.nomeElement.nativeElement.focus();
            }
          },
          error => {
            this.mostrarErros = true;
            this.mensagensDeErro = error;
          }
        );
    }
    else {
      this.pecaEmEdicao["id"] = this.idDaPecaSelecionada;
      this.pecaService.alterar(this.pecaEmEdicao)
        .subscribe(
          result => {
            if (result) {
              this.router.navigate(['/processos/pecas']);
            }
          },
          error => {
            this.mostrarErros = true;
            this.mensagensDeErro = error;
          }
        );
    }
  }

  excluir(formulario) {

    this.gravadoComSucesso = false;
    this.mostrarErros = false;
    this.mensagensDeErro = [];

    if (this.idDaPecaSelecionada) {
      this.pecaService.excluir(this.idDaPecaSelecionada)
        .subscribe(
          result => {
            if (result) {
              this.router.navigate(['/processos/pecas']);
            }
          },
          error => {
            this.mostrarErros = true;
            this.mensagensDeErro = error;
          }
        );
    }
  }

  carregarNormasSelecionadas(normas) {
    if (this.pecaEmEdicao &&  this.pecaEmEdicao.normasEControlesRelacionados) {
      this.pecaEmEdicao.normasEControlesRelacionados.forEach(norma => {
        let normaASelecionar = norma.identificadorDaNormaOuControle;
        normas.forEach(normaNoComponente => {
          if (normaNoComponente.norma.identificador == normaASelecionar) {
            normaNoComponente.selecionado = true;
          }
        });
      });
    }
  }
}
