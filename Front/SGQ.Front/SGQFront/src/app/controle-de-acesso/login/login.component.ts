import { AutenticacaoService } from './../servicos/autenticacao.service';
import { Component } from '@angular/core';
import { Router } from "@angular/router";

@Component({
  selector: 'login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  loginInvalido: boolean;
  mensagensDeErro: string[];

  constructor(
    private router: Router,
    private authService: AutenticacaoService) {
  }

  signIn(credentials) {
    this.authService.login(credentials)
      .subscribe(
        result => {
          if (result) {
            this.router.navigate(['/']);
          }
          else
            this.loginInvalido = true;
        },
        error => {
          this.mensagensDeErro = error;
          this.loginInvalido = true;
        }
      );
  }
}
