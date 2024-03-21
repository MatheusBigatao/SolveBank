import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';
@Component({
  selector: 'app-deposit',
  standalone: true,
  imports: [RouterModule, FormsModule],
  templateUrl: './deposit.component.html',
  styleUrl: './deposit.component.css',
})
export class ExternalDepositComponent {
  agencia: string = ''; // Variáveis para armazenar os valores dos campos
  conta: string = '';
  valor: string = '';

  constructor() {}

  limparCampos(): void {
    this.agencia = ''; // Atribui valores em branco para limpar os campos
    this.conta = '';
    this.valor = '';
  }
}
