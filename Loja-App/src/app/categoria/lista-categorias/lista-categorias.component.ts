import { PontosPipe } from './../pipes/lista/pontos.pipe';
import { Categoria } from './../models/categoria';
import { CategoriaService } from './../categoria.services';
import { Component, OnInit, ViewChildren, QueryList, ElementRef, ViewChild, AfterViewInit, ContentChildren } from '@angular/core';
import { CategoriaCardComponent } from '../components/categoria-card.component';
import { ActivatedRoute } from '@angular/router';
import { CategoriaMockService } from '../categoria-mock.services';
// import { CategoriaCardComponent } from "../components/CategoriaCardComponent";

@Component({
  selector: 'app-lista-categorias',
  templateUrl: './lista-categorias.component.html',
  providers: [
    PontosPipe,
  ]
})
export class ListaCategoriasComponent implements OnInit, AfterViewInit {

  @ViewChildren(CategoriaCardComponent) categoriasCardComponents: QueryList<CategoriaCardComponent>;
  // @ContentChildren(CategoriaCardComponent) tabs: QueryList<CategoriaCardComponent>

  constructor(private categoriaService: CategoriaService, private route: ActivatedRoute, private pontosPipe: PontosPipe) { }
  
  categorias: Categoria[];
  categoriasMapped: Categoria[];


  ngOnInit(): void {

    // Obtendo através do Activated Route
    this.categorias = this.route.snapshot.data['categorias'];

    this.categoriasMapped = this.categorias.map((categoria) => {
      return {
        categoriaId: categoria.categoriaId,
        descricao: this.pontosPipe.transform(categoria.descricao), // Aplicação de Pipe pelo component
        imagemUrl: categoria.imagemUrl,
        ativo: categoria.ativo
      }
    });

    console.log(this.route.snapshot.data['informacao']);

    // this.categoriaService.obterCategorias()
    //   .subscribe(response => {
    //       this.categorias = response;
    //   }, error => console.log(error));

  }
  

  mudarStatus(event: Categoria) {
    event.ativo = !event.ativo;
    this.categoriaService.alterarStatusCategoria(event)
      .subscribe((result) => {
      }, error => console.log(error));
  }

  ngAfterViewInit(): void {

  

    // this.categoriasCardComponents.changes.subscribe(t => {
    //   // console.log(this.categoriasCardComponents);
    //   // this.categoriasCardComponents.map(e => {
    //   //   console.log(e);
    //   //   e.status.emit(e.categoria);
    //   // });
    // });

    // setTimeout(() => { console.log(this.test) }, 4000);
    //console.log('Component ' + this.xablaus);
    // this.xablaus.forEach((div: ElementRef) => console.log(div.nativeElement));
  }
}
