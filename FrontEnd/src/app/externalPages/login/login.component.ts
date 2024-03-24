import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FooterRightsComponent } from '../../components/footer-rights/footer-rights.component';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { NgxMaskDirective, NgxMaskPipe } from 'ngx-mask';
import { UsuarioService } from '../../services/usuario.service';
import { Router } from '@angular/router';
import { usuarioLoginDTO } from '../../models/DTOs/UsuarioDTOs/usuarioLoginDTO';
import { AlertCustom } from '../../models/Alert/AlertCustom';
import { AlertErrorComponent } from '../../components/alert-error/alert-error.component';
import { AlertSuccessComponent } from '../../components/alert-success/alert-success.component';
import { LoadingSpinnerComponent } from '../../components/loading-spinner/loading-spinner.component';

@Component({
  selector: 'app-External-login',
  standalone: true,
  imports: [
    CommonModule,
    FooterRightsComponent,
    ReactiveFormsModule,
    NgxMaskPipe,
    NgxMaskDirective,
    AlertErrorComponent,
    AlertSuccessComponent,
    LoadingSpinnerComponent
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class ExternalLoginComponent {
  loginForm: FormGroup;
  alertCustom: AlertCustom | null = null
  alertSuccesOpen: boolean = false
  alertFailOpen: boolean = false
  loadingSpinner: boolean = false

  constructor(private usuarioServicos: UsuarioService, private _router: Router) {
    this.loginForm = new FormGroup({
      cpf_cnpj: new FormControl('', [Validators.required, Validators.minLength(11)]),
      senha: new FormControl('', Validators.required),
    });
  }

  usuarioLogin() {
    let usuarioLogin = this.loginForm.value as usuarioLoginDTO
    this.loadingSpinner = true
    this.usuarioServicos.loginUsuario(usuarioLogin).subscribe(
      {
        next: res => {
          
          this.alertCustom = new AlertCustom("Sucesso: ", "Código de acesso enviado para o seu E-mail")
          this.loadingSpinner = false
          this.alertSuccesOpen = true;
          setTimeout(() => {
            this.alertSuccesOpen = false
            this._router.navigateByUrl("/external/authentication")
          }, 4000)
        },
        error: err => {
          this.alertCustom = new AlertCustom("Erro: ", "Usuário e/ou senha incorreta, Verifique usuário e senha")
          this.loadingSpinner = false
          this.alertFailOpen = true;
          setTimeout(() => {
            this.alertFailOpen = false
          }, 5000)
        }
      }
    )

  }
}
