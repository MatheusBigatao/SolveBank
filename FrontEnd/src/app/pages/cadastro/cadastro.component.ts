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

import { RouterOutlet } from '@angular/router';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [CommonModule, RouterOutlet, ReactiveFormsModule],
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.component.css',
})
export class CadastroComponent implements OnInit {
  submitForm() {
    throw new Error('Method not implemented.');
  }
  meuFormulario: FormGroup;

  constructor() {
    this.meuFormulario = new FormGroup({
      nome: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      sobrenome: new FormControl('', Validators.required),
      cpf: new FormControl('', [
        Validators.required,
        Validators.pattern(/^\d{3}\.\d{3}\.\d{3}\-\d{2}$/),
      ]),
      senha: new FormControl('', [
        Validators.required,
        Validators.minLength(6),
        this.validarSenha(), // Adicionando validação personalizada
      ]),
      confirmarSenha: new FormControl('', Validators.required),
    });
  }

  validarSenha(): ValidatorFn {
    throw new Error('Method not implemented.');
  }

  ngOnInit(): void {}
}
