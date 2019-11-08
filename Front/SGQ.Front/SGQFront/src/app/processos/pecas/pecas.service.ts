import { AutenticacaoService } from './../../controle-de-acesso/servicos/autenticacao.service';
import { Injectable } from '@angular/core';

import { DefinicaoDeUrlsDeApis } from 'src/app/definicao-de-urls-de-apis';
import { HttpClient } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PecasService {

  constructor(
    private http: HttpClient,
    private urls: DefinicaoDeUrlsDeApis,
    private authService: AutenticacaoService) {
  }

  public obterTodas() {

    return this.http.get(this.urls.pecas, { observe: 'response', headers: this.authService.headers })
      .pipe(
        map(response => response.body),
        catchError(erro => { return throwError(erro.error); })
      );
  }
}
