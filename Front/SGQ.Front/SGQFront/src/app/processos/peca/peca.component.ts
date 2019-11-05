import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PecaService } from './peca.service';

@Component({
  selector: 'app-peca',
  templateUrl: './peca.component.html',
  styleUrls: ['./peca.component.css']
})
export class PecaComponent implements OnInit {

  mensagensDeErro: any[];
  gravadoComSucesso: boolean = false;
  mostrarErros: boolean = false;
  perfisDisponiveis = [];

  constructor(private router: Router, private pecaService: PecaService) { }

  ngOnInit() {


  }

  gravar(peca, formulario) {
    this.gravadoComSucesso = false;
    this.mostrarErros = false;
    this.mensagensDeErro = [];

    this.pecaService.criarNova(peca)
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
