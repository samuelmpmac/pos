import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DefinicaoDeUrlsDeApis } from 'src/app/definicao-de-urls-de-apis';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';
import { Peca } from './peca.entity';
import { AutenticacaoService } from 'src/app/controle-de-acesso/servicos/autenticacao.service';

@Injectable({
  providedIn: 'root'
})
export class PecaService {

  constructor(
    private http: HttpClient,
    private urls: DefinicaoDeUrlsDeApis,
    private authService: AutenticacaoService
  ) { }

  public criarNova(peca: Peca) {
    return this.http.post(this.urls.pecas, peca, { observe: 'response', headers: this.authService.headers })
      .pipe(
        map(response => true),
        catchError(erro => { return throwError(erro.error); })
      );
  }

  public alterar(peca: Peca) {
    return this.http.put(this.urls.pecas + '/' + peca.id, peca, { observe: 'response', headers: this.authService.headers })
      .pipe(
        map(response => true),
        catchError(erro => { return throwError(erro.error); })
      );
  }

  public obter(id) {
    return this.http.get(this.urls.pecas + '/' + id, { observe: 'response', headers: this.authService.headers })
      .pipe(
        map(response => response.body),
        catchError(erro => { return throwError(erro.error); })
      );
  }

  public excluir(id) {
    return this.http.delete(this.urls.pecas + '/' + id, { observe: 'response' })
      .pipe(
        map(response => true),
        catchError(erro => { return throwError(erro.error); })
      );
  }
}
