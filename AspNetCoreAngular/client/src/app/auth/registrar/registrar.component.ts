import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/service/auth.service';
import { Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators, NgForm } from '@angular/forms';

@Component({
  selector: 'app-registrar',
  templateUrl: './registrar.component.html',
  styleUrls: ['./registrar.component.scss']
})
export class RegistrarComponent implements OnInit {

  registerForm: FormGroup;
  nome = '';
  email = '';
  senha = '';
  carregandoResult = false;
  //EstadoErro = new EstadoControleErro();

  constructor(private formBuilder: FormBuilder, private router: Router, private authService: AuthService) { }

  ngOnInit() {
    this.registerForm = this.formBuilder.group({
      'nome' : [null, Validators.required],
      'email' : [null, Validators.required],
      'senha' : [null, Validators.required]
    });
  }

  onFormSubmit(form: NgForm) {
    this.authService.registrar(form)
      .subscribe(res => {
        this.router.navigate(['login']);
      }, (err) => {
        console.log(err);
        alert(err.error);
      });
  }

}

// Angular Material: Erro quando o controle inválido está sujo, é tocado ou enviado 
// export class EstadoControleErro implements ErrorStateMatcher {
  // isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
  //   const isSubmitted = form && form.submitted;
  //   return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
  // }
// }
