import { CategoriaService } from './../categoria.services';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Categoria } from '../models/categoria';

@Component({
  selector: 'app-categoria-detalhes',
  templateUrl: './categoria-detalhes.component.html',
})
export class CategoriaDetalhesComponent implements OnInit {

  constructor(private categoriaService: CategoriaService, private route: ActivatedRoute) { }

  categoria: Categoria;

  ngOnInit(): void {
    this.route.params
      .subscribe(e => {
        this.categoriaService.obter(e['id']).subscribe(c => {
          this.categoria = c;
          console.log(this.categoria);
        });
      });

  }

}
