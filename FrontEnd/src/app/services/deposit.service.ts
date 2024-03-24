import { Injectable } from '@angular/core';
import { responseExibirUsuarioDTO } from '../models/DTOs/UsuarioDTOs/responseExibirUsuarioDTO';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { uri } from './uriGlobalAcess';
import { DepositoDTO } from '../models/DTOs/DepositoDTOIs/DepositoDTO';

@Injectable({
  providedIn: 'root',
})
export class DepositService {
  usuarioLogged: responseExibirUsuarioDTO = JSON.parse(
    localStorage.getItem('userLogged') || ''
  ) as responseExibirUsuarioDTO;

  constructor(private httpClient: HttpClient) {}
  realizarDeposito(contaId: string, deposito: DepositoDTO): Observable<any> {
    return this.httpClient
      .put(`${uri}deposito/depositar/${contaId}`, deposito, {
        headers: new HttpHeaders({
          authorization: `Bearer ${this.usuarioLogged.webToken.token}`,
        }),
      })
      .pipe(
        (res) => res,
        (error) => error
      );
  }
}
