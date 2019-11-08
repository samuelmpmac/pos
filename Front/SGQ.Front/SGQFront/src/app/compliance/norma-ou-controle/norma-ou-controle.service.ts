import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DefinicaoDeUrlsDeApis } from 'src/app/definicao-de-urls-de-apis';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class NormaOuControleService {

  constructor(private http: HttpClient, private urls: DefinicaoDeUrlsDeApis) { }

  public obter() {

    return this.http.get(this.urls.compliance, { observe: 'response' })
      .pipe(
        map(response => response.body),
        catchError(erro => { return throwError(erro.error); })
      );
  }

}
