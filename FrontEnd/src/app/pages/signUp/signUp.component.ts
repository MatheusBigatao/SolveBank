import { NgxMaskPipe, NgxMaskDirective } from 'ngx-mask';
import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { OnInit } from '@angular/core';
import {
  FormGroup,
  FormControl,
  ValidatorFn,
  AbstractControl,
  Validators,
  ReactiveFormsModule,
} from '@angular/forms';

import { Router } from '@angular/router';
import { UsuarioService } from '../../services/usuario.service';
import { Usuario } from '../../models/Usuario/Usuario';
import { AlertCustom } from '../../models/Alert/AlertCustom';
import { AlertErrorComponent } from '../../components/alert-error/alert-error.component';
import { AlertSuccessComponent } from '../../components/alert-success/alert-success.component';

@Component({
  selector: 'app-signUp',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgxMaskPipe,
    NgxMaskDirective,
    AlertErrorComponent,
    AlertSuccessComponent,
  ],
  templateUrl: './signUp.component.html',
  styleUrl: './signUp.component.css',
})
export class SignUpComponent implements OnInit {
  signUpForm: FormGroup;
  alertFailOpen: boolean = false;
  alertSuccesOpen: boolean = false;
  alertCustom: AlertCustom | null = null;

  ngOnInit(): void {}
  constructor(private _userServices: UsuarioService, private _route: Router) {
    this.signUpForm = new FormGroup({
      nome: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      sobrenome: new FormControl('', Validators.required),
      cpf_cnpj: new FormControl('', [
        Validators.required,
        Validators.minLength(11),
      ]),
      senha: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
        Validators.pattern(
          /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*(),.?":{}|<>]).{8,}$/
        ),
      ]),
      confirmarSenha: new FormControl('', [
        Validators.required,
        Validators.minLength(8),
      ]),
      telefone: new FormControl('', Validators.required),
    });
  }
  // Função para permitir apenas números no campo CPF-CNPJ
  allowOnlyNumbers(event: KeyboardEvent) {
    const inputChar = String.fromCharCode(event.keyCode);
    const pattern = /[0-9]/;

    if (
      event.key === 'Backspace' ||
      event.key === 'Delete' ||
      event.key === 'ArrowLeft' ||
      event.key === 'ArrowRight' ||
      event.key === 'Enter'
    ) {
      return;
    }
    if (!pattern.test(inputChar)) {
      event.preventDefault();
    }
  }
  validatePasswords(): boolean {
    const password = this.signUpForm.get('senha')?.value;
    const confirmPassword = this.signUpForm.get('confirmarSenha')?.value;
    if (password === confirmPassword) return true;
    return false;
  }

  get passwordValidation() {
    return this.signUpForm.get('senha');
  }

  //Metodos Usuário API
  createUser() {
    let usuario = this.signUpForm.value as Usuario;
    this._userServices.cadastraUsuario(usuario).subscribe({
      next: (res) => {
        this.alertCustom = new AlertCustom(
          'Sucesso ao criar Usuário',
          'Parabéns seu cadastro foi realizado com sucesso, você sera redirecionado para página de login'
        );
        this.alertSuccesOpen = true;
        setTimeout(() => {
          this.alertSuccesOpen = false;
          this._route.navigateByUrl('/external/login');
        }, 5000);
      },
      error: (err) => {
        this.alertCustom = new AlertCustom(
          'Erro ao criar conta',
          'Verifique os dados informados, se você já possuí uma conta, tente recuperar senha'
        );
        this.alertFailOpen = true;
        setTimeout(() => {
          this.alertFailOpen = false;
        }, 5000);
        console.log(err);
      },
    });
  }
}
