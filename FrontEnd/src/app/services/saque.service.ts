import { HttpClient ,HttpHeaders} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { uri } from './uriGlobalAcess';
import { responseExibirUsuarioDTO } from '../models/DTOs/UsuarioDTOs/responseExibirUsuarioDTO';
import { SaqueDTO } from '../models/DTOs/SaqueDTOs/SaqueDTO';
@Injectable({
  providedIn: 'root'
})
export class SaqueService {
    usuarioLogged: responseExibirUsuarioDTO = JSON.parse(localStorage.getItem("userLogged") || "") as responseExibirUsuarioDTO

    constructor(private httpClient:HttpClient) { }

    sacar(saqueDTO: SaqueDTO):Observable<any>{
        var contaID = this.usuarioLogged.contasBancarias[0].id;
        return this.httpClient.put(`${uri}Saque/sacar/${contaID}`, saqueDTO, {
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
