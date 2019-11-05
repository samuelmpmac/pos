import { Usuario } from './usuario.entity';
import { Injectable } from '@angular/core';
import { DefinicaoDeUrlsDeApis } from 'src/app/definicao-de-urls-de-apis';
import { HttpClient } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {

  constructor(private http: HttpClient, private urls: DefinicaoDeUrlsDeApis) { }

  public criarNovo(usuario: Usuario) {

    return this.http.post(this.urls.usuarios, usuario, { observe: 'response' })
      .pipe(
        map(response => true),
        catchError(erro => { console.log(erro); return throwError(erro.error); })
      );
  }

  public alterar(usuario: Usuario) {

  }
}