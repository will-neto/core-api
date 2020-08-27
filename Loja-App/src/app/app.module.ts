import { PontosPipe } from './categoria/pipes/lista/pontos.pipe';
import { AuthGuard } from './admin/services/admin.guard';
// import { CategoriaModule } from './categoria/categoria.module';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms'; // Formularios Reativos
import { HttpClientModule } from '@angular/common/http'; // Requisições AJAX 
import { AppRoutingModule } from './app.routes'; // Configuração do Modulo de rotas
import { CustomFormsModule } from 'ng2-validation'; // Biblioteca de validação customizada


import { registerLocaleData } from '@angular/common'; // modulos de formatos
import localePt from '@angular/common/locales/pt'; // formato em pt
registerLocaleData(localePt) // registrar o formato pt

import { AppComponent } from './app.component';
import { MenuComponent } from './navegacao/menu/menu.component';
import { HomeComponent } from './navegacao/home/home.component';
import { NotFoundComponent } from './navegacao/not-found/not-found.component';
import { CadastroGuard } from './categoria/services/cadastro.guard';
import { TodoModule } from './demo/todo-list/todo.module';
// import { CadastroComponent } from './categoria/cadastro/cadastro.component';
// import { ListaCategoriasComponent } from './categoria/lista-categorias/lista-categorias.component';
// import { CategoriaDetalhesComponent } from './categoria/categoria-detalhes/categoria-detalhes.component';

// import { CategoriaService } from './categoria/categoria.services';

@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    HomeComponent,
    NotFoundComponent,
    // Declarar pipes aqui
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule, 
    CustomFormsModule,
    AppRoutingModule,
    TodoModule,
    // CategoriaModule,
    // [RouterModule.forRoot(rootRouterConfig, { useHash: false })]
  ],
  providers: [
    AuthGuard,
    CadastroGuard
    // CategoriaService,
    // HttpClientModule,
    // FormsModule,
    // ReactiveFormsModule, 
    // CustomFormsModule,
  ],
  exports: [
    MenuComponent,
    HomeComponent,
    NotFoundComponent,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
