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
import { v4 as uuidv4 } from 'uuid';

import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { UsuarioService } from '../../services/usuario.service';
import { Usuario } from '../../models/Usuario';
import { LoginComponent } from '../login/login.component';

@Component({
  selector: 'app-signUp',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, NgxMaskPipe, NgxMaskDirective],
  templateUrl: './signUp.component.html',
  styleUrl: './signUp.component.css',
})
export class SignUpComponent implements OnInit {

  ngOnInit(): void {
    
  }

  signUpForm: FormGroup;

  constructor(private userServices:UsuarioService, private _route: Router) {
    this.signUpForm = new FormGroup({     
      nome: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      sobrenome: new FormControl('', Validators.required),
      cpf_cnpj: new FormControl('', [
        Validators.required,
        Validators.pattern(/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/),
      ]),
      senha: new FormControl('', [
        Validators.required,
        Validators.minLength(6)
      ]),
      confirmarSenha: new FormControl('', [Validators.required]),
    },
      { validators: this.validatePasswords }
    );
  };
  validatePasswords(control: AbstractControl): { [key: string]: any }
    | null {
    const password = control.get('senha')?.value;
    const confirmPassword = control.get('confirmarSenha')?.value;
    if (password !== confirmPassword) {
      return { passwordsNotMatch: true };
    }
    return null;
  };

  //Metodos Usuário API
  createUser(){
      let usuario = this.signUpForm.value as Usuario      
      this.userServices.cadastraUsuario(usuario).subscribe({
        next: res=> {
          console.log(res)
          this._route.navigateByUrl("/login")
        },
        error: err=> {          
          console.log(err)
        }
      })
  }
}