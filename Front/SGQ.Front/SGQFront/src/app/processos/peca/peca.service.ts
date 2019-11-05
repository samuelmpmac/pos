import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DefinicaoDeUrlsDeApis } from 'src/app/definicao-de-urls-de-apis';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class PecaService {

  constructor(private http: HttpClient, private urls: DefinicaoDeUrlsDeApis) { }

  public criarNova(peca) {

    return this.http.post(this.urls.pecas, peca, { observe: 'response' })
      .pipe(
        map(response => true),
        catchError(erro => { console.log(erro); return throwError(erro.error); })
      );
  }

  public alterar(peca) {

  }
}
