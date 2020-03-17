import { Component, OnInit } from '@angular/core';
import { HttpClientModule, HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {

  title = 'Loja-App';
  categorias: any = [];

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.obterCategorias();
  }

  obterCategorias() {
    this.http.get('http://localhost:5000/api/test').subscribe(response => {
      this.categorias = response;
     }, error => {
       console.log(error);
     });
  }


}
