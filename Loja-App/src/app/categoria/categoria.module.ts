import { NgModule } from '@angular/core';  // informa que é um modulo
import { RouterModule } from '@angular/router'; // informa as rotas
import { CommonModule } from '@angular/common'; // para leitura das diretivas e pipes
import { HttpClientModule } from '@angular/common/http';
import { CategoriaRoutingModule } from './categoria.route'; // roteamento

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomFormsModule } from 'ng2-validation';

import { ListaCategoriasComponent } from './lista-categorias/lista-categorias.component';
import { CategoriaDetalhesComponent } from './categoria-detalhes/categoria-detalhes.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { CategoriaAppComponent } from './categoria.app.component';

// import { CategoriaService } from './categoria.services';
import { CategoriaCardComponent } from './components/categoria-card.component';
import { CategoriaResolve } from './categoria.resolve';
import { PontosPipe } from './pipes/lista/pontos.pipe';
import { CategoriaService } from './categoria.services';

@NgModule({
  declarations: [
    ListaCategoriasComponent,
    CategoriaDetalhesComponent,
    CadastroComponent,
    CategoriaCardComponent,
    CategoriaAppComponent,
    PontosPipe,
  ],
  imports: [
    CommonModule,
    RouterModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule, 
    CustomFormsModule,    
    CategoriaRoutingModule // Roteamento isolado
  ],
  exports: [
    ListaCategoriasComponent,
    CategoriaDetalhesComponent,
    CadastroComponent,
    PontosPipe
  ],
  providers: [
    CategoriaService,
    CategoriaResolve
  ]
})
export class CategoriaModule { }