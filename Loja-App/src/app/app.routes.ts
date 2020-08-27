import { AuthGuard } from './admin/services/admin.guard';
import { NotFoundComponent } from './navegacao/not-found/not-found.component';
// import { CategoriaDetalhesComponent } from './categoria/categoria-detalhes/categoria-detalhes.component';
// import { ListaCategoriasComponent } from './categoria/lista-categorias/lista-categorias.component';
// import { CadastroComponent } from './categoria/cadastro/cadastro.component';
import { Routes, RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { HomeComponent } from './navegacao/home/home.component';
import { TodoComponent } from './demo/todo-list/todo.component';

export const rootRouterConfig: Routes = [
    { path: '', redirectTo: '/home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'todo', component: TodoComponent },
    { path: 'categorias', 
        loadChildren: () => import('./categoria/categoria.module')
        .then(m => m.CategoriaModule)
    },
    { path: 'admin', 
        loadChildren: () => import('./admin/admin.module')
        .then(m => m.AdminModule),
        canLoad: [AuthGuard], canActivate: [AuthGuard]
    },
    
    { path: '**', component: NotFoundComponent }
    // { path: 'categorias', component: ListaCategoriasComponent },
    // { path: 'categoria/cadastro', component: CadastroComponent },
    // { path: 'categoria/detalhes/:id', component: CategoriaDetalhesComponent },
];

@NgModule({
    imports: [
        RouterModule.forRoot(rootRouterConfig /*, { enableTracing: true }*/)
    ],
    exports: [
        RouterModule
    ]
})
export class AppRoutingModule {}