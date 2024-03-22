import { Injectable } from '@angular/core';
import { Usuario } from '../models/Usuario/Usuario';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { usuarioLoginDTO } from '../models/DTOs/UsuarioDTOs/usuarioLoginDTO';
import { responseExibirUsuarioDTO } from '../models/DTOs/UsuarioDTOs/responseExibirUsuarioDTO';
import { uri } from './uriGlobalAcess';
@Injectable({
  providedIn: 'root'
})
export class UsuarioService {
  constructor(private httpRequest: HttpClient) { }
  

  cadastraUsuario(usuarioCadastro: Usuario): Observable<any> {
    return this.httpRequest.post<any>(`${uri}usuario/cadastrar/`, usuarioCadastro).pipe(
      res => res,
      error => error
    )
  }
  loginUsuario(usuarioLogin: usuarioLoginDTO): Observable<any> {
    return this.httpRequest.post<any>(`${uri}usuario/login/`, usuarioLogin).pipe(
      res => res,
      error => error
    )
  }
  autenticarUsuario(token2Fatores: string):Observable<responseExibirUsuarioDTO> {
    return this.httpRequest.get<responseExibirUsuarioDTO>(`${uri}usuario/autenticar/${token2Fatores}`).pipe(
      res => res,
      error => error
    )
  }
}



