import { Injectable } from "@angular/core";
import { CanDeactivate, ActivatedRouteSnapshot, RouterStateSnapshot } from "@angular/router";
import { CadastroComponent } from "../cadastro/cadastro.component";

@Injectable()
export class CadastroGuard implements CanDeactivate<CadastroComponent> {
    
    canDeactivate(component: CadastroComponent) {
        
        if(component.mudancasNaoSalvas){
            return window.confirm('Mudanças não salvas. Deseja sair?');
        }

        return true;
    }

}