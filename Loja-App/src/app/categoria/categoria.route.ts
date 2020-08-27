import { CadastroGuard } from './services/cadastro.guard';
import { CategoriaResolve } from './categoria.resolve';
import { CategoriaAppComponent } from './categoria.app.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ListaCategoriasComponent } from './lista-categorias/lista-categorias.component';
import { CategoriaDetalhesComponent } from './categoria-detalhes/categoria-detalhes.component';
import { CadastroComponent } from './cadastro/cadastro.component';

const categoriaRouterConfig: Routes = [
    { 
        path: '', component: CategoriaAppComponent,
        children: [
            { path: 'cadastro', component: CadastroComponent, canDeactivate: [CadastroGuard] },
            { path: '', redirectTo: 'todos' },
            { 
                path: ':estado', component: ListaCategoriasComponent,
                resolve: {
                    categorias: CategoriaResolve
                },
                data: { // RECUPERA DADOS DA URL, EX DE USO:  AUTENTICAÇÃO/AUTORIZAÇÃO
                    informacao: 'teste'
                }
             },
            { path: 'detalhes/:id', component: CategoriaDetalhesComponent }
        ]
    },
   
];

@NgModule({
    imports: [
        RouterModule.forChild(categoriaRouterConfig)
    ],
    exports: [
        RouterModule
    ]
})
export class CategoriaRoutingModule {}
