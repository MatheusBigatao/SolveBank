import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { uri } from './uriGlobalAcess';
import { responseExibirUsuarioDTO } from '../models/DTOs/UsuarioDTOs/responseExibirUsuarioDTO';

@Injectable({
  providedIn: 'root'
})
export class ContaBancariaService {
  usuarioLogged: responseExibirUsuarioDTO = JSON.parse(localStorage.getItem("userLogged") || "") as responseExibirUsuarioDTO

  constructor(private httpClient: HttpClient) {}

  consultarSaldo(contaId: string): Observable<any>{
    return this.httpClient.get(`${uri}ContaBancaria/saldo/${contaId}`, {
      headers: new HttpHeaders({
        'authorization': `Bearer ${this.usuarioLogged.webToken.token}`
      })
    }
    ).pipe(
      res => res,
      error => error
    )
  }
}
