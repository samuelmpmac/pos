import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AutenticacaoService } from './autenticacao.service';

@Injectable({
  providedIn: 'root'
})
export class PerfilAuthGuard implements CanActivate {

  constructor(
    private router: Router,
    private authService: AutenticacaoService,

  ) { }

  canActivate(route: ActivatedRouteSnapshot): boolean {
    if (this.authService.usuarioLogadoPossuiPerfil(route.data.perfil)) {
      return true;
    }
    this.router.navigate(['/sem-acesso']);
    return false;

  }


}


