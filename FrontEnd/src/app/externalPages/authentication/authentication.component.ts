import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { UsuarioService } from '../../services/usuario.service';
import { responseExibirUsuarioDTO } from '../../models/DTOs/UsuarioDTOs/responseExibirUsuarioDTO';

@Component({
  selector: 'app-authentication',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './authentication.component.html',
  styleUrl: './authentication.component.css'
})
export class ExternalAuthenticationComponent {
  authForm: FormGroup;
  usuarioLogado: responseExibirUsuarioDTO | null = null
  ngOnInit(){
    let usuarioLogged = JSON.parse(localStorage.getItem("userLogged")||"") as responseExibirUsuarioDTO
    this.usuarioLogado = usuarioLogged
    console.log(this.usuarioLogado?.contaBancarias)
  }
  constructor(private userService: UsuarioService, private _router: Router) {
    this.authForm = new FormGroup({
      token: new FormControl('', [Validators.required, Validators.minLength(8)])
    });
  }


  authUser() {
    let token = this.authForm.value
    this.userService.autenticarUsuario(token.token).subscribe(
      {
        next: res => {
          localStorage.setItem("userLogged", JSON.stringify(res))
          let usuarioLogged = JSON.parse(localStorage.getItem("userLogged")||"") as responseExibirUsuarioDTO
               
        },
        error:err=>{
          
        }
      }
    )
  }
}
