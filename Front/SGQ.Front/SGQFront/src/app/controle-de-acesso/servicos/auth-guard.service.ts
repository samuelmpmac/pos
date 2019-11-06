import { AutenticacaoService } from './autenticacao.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {

  constructor(private authService: AutenticacaoService, private router: Router) { }

  canActivate(): boolean {
    if (this.authService.usuarioEstaLogado) {
      return true;
    }
    this.router.navigate(['/login']);
    return false;
  }
}
