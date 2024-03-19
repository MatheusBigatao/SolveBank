import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TransacaoService {

  constructor() { }
  private uriApi = "https://api-tscontrol.marcusvogado.com/tsc/api/applicationuser/commonuser"
}
