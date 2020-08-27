import { CategoriaService } from './../categoria.services';
import { Component, OnInit, ElementRef, ViewChildren } from '@angular/core';
import { FormGroup, FormBuilder, Validators, FormControlName } from '@angular/forms';
import { Categoria } from '../models/categoria';
import { CustomValidators } from 'ng2-validation';
import { ValidationMessages, GenericValidator, DisplayMessage } from './generic-form-validation';
import { Observable, fromEvent, merge } from 'rxjs';
import { Router } from '@angular/router';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html',
})

export class CadastroComponent implements OnInit {


  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[];

  cadastroForm: FormGroup; // associa com atributo no html
  categoria: Categoria;

  mudancasNaoSalvas: boolean;

  // VALIDAÇÕES
  validationMessages: ValidationMessages;
  genericValidator: GenericValidator;
  displayMessage: DisplayMessage = {};

  constructor(private fb: FormBuilder, private categoriaService: CategoriaService, private router: Router) {

    this.validationMessages = {
      descricao: {
        required: 'Campo obrigatório.',
        maxlength: 'Deve ter no máximo 60 caracteres.'
      },
      imagemUrl: {
        required: 'Campo obrigatório.',
        rangeLength: 'Deve possuir entre 5 a 60 caracteres.'
      }
    };

    this.genericValidator = new GenericValidator(this.validationMessages);

  } 

  ngOnInit(): void {


    // Recomendado utilização de FormBuilder
    // this.cadastroForm = this.fb.group({
    //   descricao: ['', [Validators.required, Validators.maxLength(60)]], // adicionar campos do formulario  | validação
    //   imagemUrl: ['', [Validators.required, Validators.maxLength(60)]], // o FormBuilder simplifica a chamada e declaração dos campos com menos código
    //   ativo: ['false'] // Dentro vai o valor padrão do campo
    // });

    this.cadastroForm = this.fb.group({
      descricao: ['', [Validators.required, Validators.maxLength(60)]], 
      imagemUrl: ['', [Validators.required, CustomValidators.rangeLength([5, 60])]], // Via Custom Validators
      ativo: ['false'] 
    });
    
    // this.cadastroForm = new FormGroup({
    //   descricao: new FormControl(''), // adicionar campos do formulario
    //   imagemUrl: new FormControl(''), // Dentro da instancia vai o valor padrao do campo
    //   ativo: new FormControl('') 
    // });
  }

  adicionarCategoria(){

    if(this.cadastroForm.dirty && this.cadastroForm.valid){

      this.categoria = Object.assign({}, this.categoria, this.cadastroForm.value);

      console.log(this.categoria);

      this.categoriaService.adicionarCategoria(this.categoria)
        .subscribe(result => {
          console.log(result);
          this.router.navigate(['/categorias']);
        }, error => console.log(error));

      this.mudancasNaoSalvas = false;
      // console.log(JSON.stringify(this.cadastroForm.value));
      // console.log(this.categoria);
    
    } else {
      
    }
  }

  ngAfterViewInit(): void {
    let controlBlurs: Observable<any>[] = this.formInputElements
    .map((formControl: ElementRef) => fromEvent(formControl.nativeElement, 'blur'));

    this.formInputElements.map((formControl: ElementRef) => console.log(formControl));

    

    merge(...controlBlurs).subscribe(() => {
      this.displayMessage = this.genericValidator.processarMensagens(this.cadastroForm);
      this.mudancasNaoSalvas = true;
    });

  }
}
