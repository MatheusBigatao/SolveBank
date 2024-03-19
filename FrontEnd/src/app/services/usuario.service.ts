import { Injectable } from '@angular/core';
import { Usuario } from '../models/Usuario';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { usuarioLoginDTO } from '../models/DTOs/UsuarioDTOs/usuarioLoginDTO';

@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  constructor(private httpRequest: HttpClient) { }
  private uri = "https://localhost:44373/api/usuario"

  cadastraUsuario(usuarioCadastro: Usuario): Observable<any> {
    return this.httpRequest.post<any>(`${this.uri}/cadastrar`, usuarioCadastro).pipe(
      res => res,
      error => error
    )
  }
  loginUsuario(usuarioLogin:usuarioLoginDTO):Observable<any>{
    return this.httpRequest.post<any>(`${this.uri}/login`,usuarioLogin).pipe(
      res => res,
      error => error
    )
  }
}



