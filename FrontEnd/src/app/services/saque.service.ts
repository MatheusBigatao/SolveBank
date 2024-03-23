import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { uri } from './uriGlobalAcess';
import { SaqueDTO } from '../models/DTOs/SaqueDTOs/SaqueDTO';
@Injectable({
  providedIn: 'root'
})
export class SaqueService {

    constructor(private httpRequest:HttpClient) { }

    sacar(contaID: string, saqueDTO: SaqueDTO):Observable<any>{
        return this.httpRequest.put<SaqueDTO>(`${uri}sacar/${contaID}`, saqueDTO).pipe(
            res => res,
            error => error
          )
    }
}
