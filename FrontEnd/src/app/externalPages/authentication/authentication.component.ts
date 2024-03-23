import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioService } from '../../services/usuario.service';
import { responseExibirUsuarioDTO } from '../../models/DTOs/UsuarioDTOs/responseExibirUsuarioDTO';
import { AlertErrorComponent } from '../../components/alert-error/alert-error.component';
import { AlertCustom } from '../../models/Alert/AlertCustom';
import { LoadingSpinnerComponent } from '../../components/loading-spinner/loading-spinner.component';

@Component({
  selector: 'app-authentication',
  standalone: true,
  imports: [
    CommonModule,
    ReactiveFormsModule,
    AlertErrorComponent,
    LoadingSpinnerComponent
  ],
  templateUrl: './authentication.component.html',
  styleUrl: './authentication.component.css'
})
export class ExternalAuthenticationComponent {
  authForm: FormGroup;
  usuarioLogado: responseExibirUsuarioDTO | null = null
  alertCustom: AlertCustom | null = null
  alertFailOpen: boolean = false
  loadingSpinner: boolean = false
  ngOnInit() {
  }
  constructor(private userService: UsuarioService, private _router: Router) {
    this.authForm = new FormGroup({
      token: new FormControl('', [Validators.required, Validators.minLength(8)])
    });
  }


  authUser() {
    let token = this.authForm.value
    this.loadingSpinner = true
    this.userService.autenticarUsuario(token.token).subscribe(
      {
        next: res => {
          localStorage.setItem("userLogged", JSON.stringify(res.usuario))
          setTimeout(()=>{
            this.loadingSpinner = false
            this._router.navigateByUrl("/external/home")
          },3000)         
          
        },
        error: err => {
          this.alertCustom = new AlertCustom("Erro", "Código inválido, verifique seu E-mail")
          this.loadingSpinner = false
          this.alertFailOpen = true;
          setTimeout(() => {
            this.alertFailOpen = false           
          }, 4000)
        }
      }
    )
  }
  returnLoginPage(){
    this._router.navigateByUrl("/external/login")
  }
}
