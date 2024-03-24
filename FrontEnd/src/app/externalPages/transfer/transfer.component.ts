import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuHomeComponent } from '../../components/menu-home/menu-home.component';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { Router } from '@angular/router';
import { RouterModule } from '@angular/router';
import { TransferenciaService } from '../../services/transferencia.service';
import { TransferenciaDTO } from '../../models/DTOs/TransferenciaDTOs/TransferenciaDTO';
import { AlertCustom } from '../../models/Alert/AlertCustom';
import { AlertErrorComponent } from '../../components/alert-error/alert-error.component';
import { AlertSuccessComponent } from '../../components/alert-success/alert-success.component';
import { LoadingSpinnerComponent } from '../../components/loading-spinner/loading-spinner.component';
import { responseExibirUsuarioDTO } from '../../models/DTOs/UsuarioDTOs/responseExibirUsuarioDTO';

@Component({
  selector: 'app-transfer',
  standalone: true,
  templateUrl: './transfer.component.html',
  styleUrl: './transfer.component.css',
  imports: [
    CommonModule,
    MenuHomeComponent,
    ReactiveFormsModule,
    RouterModule,
    AlertErrorComponent,
    AlertSuccessComponent,
    LoadingSpinnerComponent
  ]
})
export class ExternalTransferComponent {
  transferForm: FormGroup;
  alertCustom: AlertCustom | null = null
  alertSuccesOpen: boolean = false
  alertFailOpen: boolean = false
  loadingSpinner: boolean = false
  constructor(private transferenciaService: TransferenciaService, private _router: Router) {
    this.transferForm = new FormGroup({
        beneficiario: new FormControl('', [
      ]),
      agenciaDestino: new FormControl('', [
        Validators.required,
        Validators.pattern(/^\d{4}$/),
      ]),
      numeroContaDestino: new FormControl('', [
        Validators.required,
      ]),
      valor: new FormControl('', Validators.required),
    });
  }

  valueFormatter(event: any) {
    let value = event.target.value;
    value = value.replace(/\D/g, '');
    value = parseInt(value, 10) / 100;

    if (!isNaN(value)) {
      const formattedValue =
        'R$ ' + value.toLocaleString('pt-BR', { minimumFractionDigits: 2 });
      this.transferForm.controls['value'].setValue(formattedValue);
    } else {
      this.transferForm.controls['value'].setValue('R$ 0,00');
    }
  }

  transferir(){
    this.transferenciaService.transferir().subscribe()
  }

}
