import { PecasService } from './pecas.service';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-pecas',
  templateUrl: './pecas.component.html',
  styleUrls: ['./pecas.component.css']
})
export class PecasComponent implements OnInit {

  public pecas;

  constructor(private usuariosService: PecasService) { }

  ngOnInit() {
    this.usuariosService.obterTodas()
    .subscribe(
      result => {
        if (result) {
          this.pecas = result;
        }
      },
      error => {
      }
    );
  }

}
