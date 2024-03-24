import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { uri } from './uriGlobalAcess';
import { responseExibirUsuarioDTO } from '../models/DTOs/UsuarioDTOs/responseExibirUsuarioDTO';
import { TransferenciaDTO } from '../models/DTOs/TransferenciaDTOs/TransferenciaDTO';
@Injectable({
  providedIn: 'root'
})
export class TransferenciaService {
	usuarioLogged: responseExibirUsuarioDTO = JSON.parse(localStorage.getItem("userLogged") || "") as responseExibirUsuarioDTO

  	constructor(private httpRequest:HttpClient) { }

	transferir(transferenciaDTO:TransferenciaDTO):Observable<any>{
		var contaID = this.usuarioLogged.contasBancarias[0].id;
		return  this.httpRequest.put(`${uri}transferencia/transferir/${contaID}`, transferenciaDTO,{
			headers: new HttpHeaders({
				'authorization': `Bearer ${this.usuarioLogged.webToken.token}`
			})
  	}).pipe(
			res => res,
			error => error
		)
}
}
