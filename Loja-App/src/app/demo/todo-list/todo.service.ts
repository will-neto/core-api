import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { Task } from './task';
import { Store } from './todo.store';
import { tap } from 'rxjs/operators';

@Injectable()
export class TasksService {

  constructor(private http: HttpClient, private store: Store) { }

  getTodoList$: Observable<Task[]> = this.http
    .get<Task[]>('http://localhost:3000/todolist')
      .pipe(tap(next => {
        
        this.store.set('todolist', next)

      } ));

    toggle(event: any){
      
      console.log(event);

      this.http
        .put(`http://localhost:3000/todolist/${event.id}`, event)
        .subscribe(() => {
          const value = this.store.value.todolist;
          const todolist = value.map((task: Task) => {
            if(event.id === task.id){
              return { ...task, ...event };
            }

            return task;      
          })

          this.store.set('todolist', todolist);

        });
    }

  /* getToDoList(): Observable<Task[]> {
    return this.http
      .get<Task[]>('http://localhost:3000/todolist');
  } */
}