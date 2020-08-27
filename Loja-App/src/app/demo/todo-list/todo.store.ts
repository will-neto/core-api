import { Task } from './task';
import { BehaviorSubject, Observable } from 'rxjs';
import { map } from 'rxjs/operators';

export interface State {
    todolist: Task[];
}

const state: State = {
    todolist: []
}

export class Store {
    private subject = new BehaviorSubject<State>(state); // Propaga estado atual da Store
    private store = this.subject.asObservable(); // Transforma em Observable

    get value(){
        return this.subject.value; // Retorna o valor do objeto BehaviorSubject - estado
    }

    public getTodoList(): Observable<Task[]>{

        return this.store
            .pipe(map(store => store.todolist));
            
    }

    set(name: string, state: any){

        // console.log(this.value);
        // console.log([name]);
        // console.log(name);
        // console.log(state);
    
    
        this.subject.next({
            ...this.value, [name]: state
        });
        
      

    }
}