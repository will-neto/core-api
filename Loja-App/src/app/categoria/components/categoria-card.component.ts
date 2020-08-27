import { Component, Input, Output, EventEmitter } from "@angular/core";
import { Categoria } from "../models/categoria";

@Component({
    selector: 'categoria-card',
    templateUrl: './categoria-card.component.html'
})
export class CategoriaCardComponent {
 
    // @ViewChildren('xablau', { read: ElementRef }) testeElements: ElementRef[];
    
    @Input()
    categoria: Categoria;

    @Output()
    status: EventEmitter<any> = new EventEmitter<any>();

    emitirEvento(){
        this.status.emit(this.categoria);
    }


}