import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators, NgForm, FormGroupDirective, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm: FormGroup;
  email = '';
  senha = '';
  //EstadoErro = new EstadoControleErro();
  carregandoResult = false;

  constructor(private formBuilder: FormBuilder, private router: Router, private authService: AuthService) { 
    
  }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({
      'email' : [null, Validators.required],
      'senha' : [null, Validators.required]
    });
  }

  onFormSubmit(form: NgForm) {
    this.authService.login(form)
      .subscribe(res => {
        console.log(res);
        if (res.token) {
          localStorage.setItem('token', res.token);
          this.router.navigate(['produto']);
        }
      }, (err) => {
        console.log(err);
      });
    }

    registrar() {
      this.router.navigate(['registrar']);
    }
}

// Angular Material: Erro quando o controle inválido está sujo, é tocado ou enviado 
// export class EstadoControleErro implements ErrorStateMatcher {
//   isErrorState(control: FormControl | null, form: FormGroupDirective | NgForm | null): boolean {
//     const isSubmitted = form && form.submitted;
//     return !!(control && control.invalid && (control.dirty || control.touched || isSubmitted));
//   }
// }