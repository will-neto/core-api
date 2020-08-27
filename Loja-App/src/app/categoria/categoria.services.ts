import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Categoria } from './models/categoria';
import { Observable } from 'rxjs';

@Injectable()
export class CategoriaService { 

    constructor(private http: HttpClient) { }

    protected UrlServiceV1: string = "http://localhost:57366/api/";



    // obterTodos(estado: string): Categoria[] {
        
    //     var categorias: Categoria[] = [];
        
    //     this.obterCategorias()
    //         .subscribe(result => { 

    //             categorias == result;

    //             if (estado === "ativos")
    //                 return categorias.filter(c => c.ativo);
    //         } );

    //     return categorias;
    // }


    obterCategorias() : Observable<Categoria[]> {
        return this.http.get<Categoria[]>(this.UrlServiceV1 + "categorias");
    }

    obter(id: number) : Observable<Categoria> {
        return this.http.get<Categoria>(this.UrlServiceV1 + `categorias/${id}`);
    }

    adicionarCategoria(categoria: Categoria) : Observable<any> {
        return this.http.post<any>(this.UrlServiceV1 + "categorias", categoria);
    }

    alterarStatusCategoria(categoria: Categoria) : Observable<any> {
        return this.http.put<any>(this.UrlServiceV1 + "categorias", categoria);
    }


}