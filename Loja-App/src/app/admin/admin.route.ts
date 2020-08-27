import { AdminDashboardComponent } from './admin-dashboard/admin-dashboard.component';
import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";

const categoriaRouterConfig: Routes = [   
    { 
        path: '', component: AdminDashboardComponent,
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
export class AdminRoutingModule {}