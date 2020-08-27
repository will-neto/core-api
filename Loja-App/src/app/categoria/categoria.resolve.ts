import { CategoriaService } from './categoria.services';
import { Injectable } from "@angular/core";
import { Resolve, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { Categoria } from "./models/categoria";

@Injectable()
export class CategoriaResolve implements Resolve<Categoria[]> {

    constructor(private categoriaService: CategoriaService){}

    categorias: Categoria[] = [];

    async resolve(route: ActivatedRouteSnapshot) {
   
        var estado = route.params.estado;
    
        // Converter Observable para Promise, desta forma aguarda o resultado
        this.categorias = await this.categoriaService.
            obterCategorias().toPromise();
    
        if (estado === "ativos")
            this.categorias = this.categorias.filter(c => c.ativo);

        return this.categorias;
      
    }


    // buscarCategorias() {
    //     return this.categoriaService.obterCategorias()
    //         .subscribe(result => { 
    //             this.categorias = result;
    //             console.log(this.categorias);
    //     });
    // }

 }