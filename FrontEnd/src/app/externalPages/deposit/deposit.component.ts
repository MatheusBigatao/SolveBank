import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import {
  AbstractControl,
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  ValidationErrors,
  Validators,
} from '@angular/forms';
import { CommonModule } from '@angular/common';
import { DepositoDTO } from '../../models/DTOs/DepositoDTOIs/DepositoDTO';
import { responseExibirUsuarioDTO } from '../../models/DTOs/UsuarioDTOs/responseExibirUsuarioDTO';
import { DepositService } from '../../services/deposit.service';
import { AlertCustom } from '../../models/Alert/AlertCustom';
import { AlertErrorComponent } from '../../components/alert-error/alert-error.component';
import { AlertSuccessComponent } from '../../components/alert-success/alert-success.component';
import { LoadingSpinnerComponent } from '../../components/loading-spinner/loading-spinner.component';
import { Router } from '@angular/router';
@Component({
  selector: 'app-deposit',
  standalone: true,
  imports: [
    RouterModule,
    ReactiveFormsModule,
    CommonModule,
    AlertErrorComponent,
    AlertSuccessComponent,
    LoadingSpinnerComponent,
  ],
  templateUrl: './deposit.component.html',
  styleUrl: './deposit.component.css',
})
export class ExternalDepositComponent {
  usuarioLogged: responseExibirUsuarioDTO = JSON.parse(
    localStorage.getItem('userLogged') || ''
  ) as responseExibirUsuarioDTO;

  alertCustom: AlertCustom | null = null;
  alertSuccesOpen: boolean = false;
  alertFailOpen: boolean = false;
  loadingSpinner: boolean = false;
  valorDeposito: boolean = false;
  depositForm: FormGroup;
  constructor(
    private depositoServicos: DepositService,
    private _router: Router
  ) {
    this.depositForm = new FormGroup({
      valorDeposito: new FormControl('', [
        Validators.required
      ]),
      codigoEnvelope: new FormControl('', [
        Validators.required,
        Validators.minLength(4),
      ]),
    });
  }

  limparCampos(): void {
    this.depositForm.reset();
  }
  valueFormatter(event: any) {
    let value = event.target.value;
    value = value.replace(/\D/g, '');
    value = parseInt(value, 10) / 100;  
    this.valorDeposito = parseFloat(value) >= 10 && parseFloat(value) <= 5000 ? true : false 
    if (!isNaN(value)) {
      const formattedValue = value.toLocaleString('pt-BR', {
        minimumFractionDigits: 2,
      });
      this.depositForm.controls['valorDeposito'].setValue(formattedValue);
    } else {
      this.depositForm.controls['valorDeposito'].setValue('R$ 0,00');
    }
  }

  realizarDeposito() {
    let deposit = this.depositForm.value as DepositoDTO;
    deposit.valorDeposito = this.parseFloatCustom(
      deposit.valorDeposito.toString()
    );
    this.depositoServicos
      .realizarDeposito(this.usuarioLogged.contasBancarias[0].id, deposit)
      .subscribe({
        next: (res) => {
          this.alertCustom = new AlertCustom(
            'Sucesso: ',
            'Depósito efetuado com sucesso'
          );
          this.loadingSpinner = false;
          this.alertSuccesOpen = true;
          setTimeout(() => {
            this.alertSuccesOpen = false;
            this._router.navigateByUrl('/external/home');
          }, 4000);
        },
        error: (err) => {
          this.alertCustom = new AlertCustom(
            'Erro: ',
            'Erro ao efetuar Depósito'
          );
          this.loadingSpinner = false;
          this.alertFailOpen = true;
          setTimeout(() => {
            this.alertFailOpen = false;
          }, 5000);
        },
      });
  }
  parseFloatCustom(value: string) {
    value = value.replace(/\./g, '');
    value = value.replace(',', '.');
    let floatValue = parseFloat(value);
    return floatValue;
  }

}
