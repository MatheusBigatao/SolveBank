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

@Component({
  selector: 'app-signUp',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, NgxMaskPipe, NgxMaskDirective],
  templateUrl: './signUp.component.html',
  styleUrl: './signUp.component.css',
})
export class SignUpComponent implements OnInit {

  ngOnInit(): void {
    console.log(this.signUpForm.value)
  }

  signUpForm: FormGroup;

  constructor(private _http: HttpClient, private _route: Router) {
    this.signUpForm = new FormGroup({
      id: new FormControl(uuidv4()),
      nome: new FormControl('', Validators.required),
      email: new FormControl('', [Validators.required, Validators.email]),
      sobrenome: new FormControl('', Validators.required),
      cpf: new FormControl('', [
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

  async generateRandomNumber(min: number, max: number): Promise<number> {
    let numeroDaConta = Math.floor(Math.random() * (max - min + 1)) + min;
    const res = await this._http.get<any>('http://localhost:3000/contas').toPromise();
    const conta = res.find((c: any) => c.conta === numeroDaConta);
    if (conta) {
      return this.generateRandomNumber(min, max);
    }
    return numeroDaConta;
  }

  submittingForm: boolean = false;

  submitForm() {
    if (this.submittingForm) {
      return;
    }

    this.submittingForm = true;

    const formData = { ...this.signUpForm.value };
    delete formData.confirmarSenha;
    this._http.post('http://localhost:3000/users', formData).subscribe(
      (userData: any) => {
        const usuarioId = userData.id; // Assume que o objeto retornado contém um campo id
        alert('Usuário cadastrado com sucesso!');
        this.generateRandomNumber(1, 1000000).then((numeroDaConta) => {
          this._http.post('http://localhost:3000/contas', { id: uuidv4(), agencia: 1313, conta: numeroDaConta, saldo: 0, usuarioId })
            .subscribe(() => {
              this._route.navigate(['/login']);
              console.log("Conta criada");
              this.submittingForm = false;
            });
        });
      },
      (error) => {
        console.log(error);
        this.submittingForm = false;
      }
    );
  }
}