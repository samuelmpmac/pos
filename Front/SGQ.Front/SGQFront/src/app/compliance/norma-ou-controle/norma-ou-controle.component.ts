import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Router } from '@angular/router';
import { NormaOuControleService } from './norma-ou-controle.service';

@Component({
  selector: 'norma-ou-controle',
  templateUrl: './norma-ou-controle.component.html',
  styleUrls: ['./norma-ou-controle.component.css']
})
export class NormaOuControleComponent implements OnInit {

  @Output() normasCarregadas = new EventEmitter();

  constructor(private router: Router, private normaService: NormaOuControleService) { }
  normas: any;
  ngOnInit() {
    this.normas = [];
    this.normaService.obter()
      .subscribe(
        (result: any[]) => {
          if (result) {
            console.log('nr,', result);
            result.forEach(element => {
              this.normas.push({ norma: element, selecionado: false });
            });
            this.normasCarregadas.emit(this.normas);
          }
        },
        error => {
        }
      );
  }
  get normasSelecionadas() {
    let retorno = [];
    this.normas.forEach(norma => {
      if (norma.selecionado) {
        retorno.push(norma.norma.identificador);
      }
    });
    return retorno;
  }
  logTeste() {
    console.log(this.normasSelecionadas);
  }

}
