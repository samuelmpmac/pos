import { Component, OnInit } from '@angular/core';
import { fromEventPattern } from 'rxjs';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  public get usuarios() {
    let a = [];
    for (let i = 0; i < 1000; i++) {
      a.push({ id: '1111', email: 'samuel.macedo@mxm.com.br', nome: 'Samuel Machado Pina de Macedo' });
    }
    return a;

  }
}
