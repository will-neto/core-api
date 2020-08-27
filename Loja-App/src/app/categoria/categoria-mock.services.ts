import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Categoria } from './models/categoria';
import { Observable } from 'rxjs';

@Injectable()
export class CategoriaMockService { 

    constructor(private http: HttpClient) { }

    protected UrlServiceV1: string = "http://localhost:57366/api/";


    obterCategorias() : Observable<Categoria[]> {
        return new Observable<Categoria[]>(subscriber => {
            
            var categorias: Categoria[] = [{
                categoriaId: 1,
                descricao: 'categorias - obterCategorias()',
                ativo: true,
                imagemUrl: ''
              }];

            subscriber.next(categorias);
        });
    }

    obter(id: number) : Observable<Categoria> {
        return new Observable<Categoria>(subscriber => {
                  
            var categoria: Categoria = {
                descricao: 'categoria - obter()',
                ativo: true,
                categoriaId: 1,
                imagemUrl: ''
            };

            subscriber.next(categoria);
        });
    }

    adicionarCategoria(categoria: Categoria) : Observable<any> {
        return new Observable<any>(subscriber => {   
            
            var result = JSON.stringify( { success: true });
            subscriber.next(result);
        });
    }

    alterarStatusCategoria(categoria: Categoria) : Observable<any> {
        return new Observable<any>(subscriber => {   
            
            var result = JSON.stringify( { success: true });
            subscriber.next(result);
        }); 
    }


}