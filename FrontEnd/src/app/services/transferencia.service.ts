import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { uri } from './uriGlobalAcess';
@Injectable({
  providedIn: 'root'
})
export class TransferenciaService {

  constructor(private httpRequest:HttpClient) { }

  transferir():Observable<any>{
   return  this.httpRequest.get(uri)
  }
}
