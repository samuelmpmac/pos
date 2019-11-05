import { Injectable } from '@angular/core';
import { DefinicaoDeUrlsDeApis } from 'src/app/definicao-de-urls-de-apis';
import { HttpClient } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuariosService {

  constructor(private http: HttpClient, private urls: DefinicaoDeUrlsDeApis) {

  }

  public obterTodos() {
    console.log(this.urls.usuarios);
    return this.http.get(this.urls.usuarios, { observe: 'response' })
      .pipe(
        map(response => response.body),
        catchError(erro => { console.log(erro); return throwError(erro.error); })
      );
  }
}
