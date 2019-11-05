import { Component, OnInit } from '@angular/core';
import { fromEventPattern } from 'rxjs';
import { UsuariosService } from './usuarios.service';

@Component({
  selector: 'app-usuarios',
  templateUrl: './usuarios.component.html',
  styleUrls: ['./usuarios.component.css']
})
export class UsuariosComponent implements OnInit {

  constructor(private usuariosService: UsuariosService) { }

  public usuarios;

  ngOnInit() {

    this.usuariosService.obterTodos()
      .subscribe(
        result => {
          if (result) {
            this.usuarios = result;
          }
        },
        error => {
        }
      );
  }



}
