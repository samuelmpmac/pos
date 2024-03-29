import { DefinicaoDeUrlsDeApis } from './../../definicao-de-urls-de-apis';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map, catchError } from 'rxjs/operators';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AutenticacaoService {


  constructor(private http: HttpClient, private urls: DefinicaoDeUrlsDeApis) {
  }

  login(credentials) {
    return this.http.post(this.urls.login, credentials, { observe: 'response' })
      .pipe(
        map(response => this.trataRetorno(response)),
        catchError(erro => throwError(erro.error))
      );
  }

  private trataRetorno(response) {
    localStorage.setItem('token', response.body.token);
    return true;
  }

  logout() {
    localStorage.removeItem('token');
  }

  get usuarioEstaLogado(): boolean {

    let jwtHelper = new JwtHelperService();
    let token = localStorage.getItem('token');
    if (!token) {
      return false;
    }
    let isExpired = jwtHelper.isTokenExpired(token);
    return !isExpired;
  }

  get usuarioLogado(): any {
    if (!this.usuarioEstaLogado) {
      return null;
    }
    let token = localStorage.getItem('token');
    let jwtHelper = new JwtHelperService();
    return jwtHelper.decodeToken(token);

  }

  usuarioLogadoPossuiPerfil(nomeDoPerfil: string) {
    let usuario = this.usuarioLogado;
    if (this.usuarioLogado == null) return false;
    let perfis: string[] = this.usuarioLogado.Perfis.split(',');
    return perfis.indexOf(nomeDoPerfil) != -1;
  }

  get headers(): HttpHeaders {
    let token = localStorage.getItem('token');
    if (!token) {
      return null;
    }

    let headers_autenticacao = new HttpHeaders({
      Authorization: 'Bearer ' + token
    });
    return headers_autenticacao;
  }
}
