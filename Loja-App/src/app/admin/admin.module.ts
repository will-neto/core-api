import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { NgModule } from '@angular/core';  // informa que é um modulo
import { CommonModule } from '@angular/common'; // para leitura das diretivas e pipes
// import { RouterModule } from '@angular/router'; // informa as rotas
// import { HttpClientModule } from '@angular/common/http';

import { AdminRoutingModule } from './admin.route';

@NgModule({
    declarations: [
        AdminDashboardComponent
    ],
    imports: [
        CommonModule,
        // RouterModule,
        // HttpClientModule,
        AdminRoutingModule // Roteamento isolado
    ],
    exports: [

    ]
})
export class AdminModule {}