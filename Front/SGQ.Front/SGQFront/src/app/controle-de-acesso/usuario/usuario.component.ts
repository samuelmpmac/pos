import { Component, OnInit } from '@angular/core';
import { PerfisDeAcessoDisponiveis, TextoDosPerfisDeAcessoDisponiveis } from '../perfis-de-acesso/perfis-de-acesso-disponiveis';

@Component({
  selector: 'app-usuario',
  templateUrl: './usuario.component.html',
  styleUrls: ['./usuario.component.css']
})
export class UsuarioComponent implements OnInit {

  public get perfisDisponiveis(){
let perfis = []
    TextoDosPerfisDeAcessoDisponiveis.forEach((value: string, key: number) => {
      perfis.push({ nome: value, valor: PerfisDeAcessoDisponiveis[key] });
  });
return perfis;
  }
  
  constructor() { }

  ngOnInit() {
  }

}
