import { Pipe, PipeTransform } from "@angular/core";

@Pipe({
    name: 'pontos'
})
export class PontosPipe implements PipeTransform {

    transform(text: string) {
        return text + '...';
    }

}