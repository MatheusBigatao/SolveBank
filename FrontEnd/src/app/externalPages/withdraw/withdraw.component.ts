import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormGroup, FormControl, Validators, ValidationErrors, AbstractControl, FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { SaqueService } from '../../services/saque.service';
import { SaqueDTO } from '../../models/DTOs/SaqueDTOs/SaqueDTO';
import { AlertCustom } from '../../models/Alert/AlertCustom';
import { AlertErrorComponent } from '../../components/alert-error/alert-error.component';
import { AlertSuccessComponent } from '../../components/alert-success/alert-success.component';
import { LoadingSpinnerComponent } from '../../components/loading-spinner/loading-spinner.component';

@Component({
  selector: 'app-withdraw',
  standalone: true,
  imports: [
    RouterModule,
    FormsModule,
    ReactiveFormsModule,
    CommonModule,
    AlertErrorComponent,
    AlertSuccessComponent,
    LoadingSpinnerComponent
],
  templateUrl: './withdraw.component.html',
  styleUrl: './withdraw.component.css',
})
export class ExternalWithdrawComponent {
  valorSaque: number = NaN;
  saqueForm: FormGroup;
  alertCustom: AlertCustom | null = null
  alertSuccesOpen: boolean = false
  alertFailOpen: boolean = false
  loadingSpinner: boolean = false

  constructor(private saqueServicos:SaqueService, private _router: Router) {
    this.saqueForm = new FormGroup({
        valorSaque: new FormControl('', [Validators.required, this.minimoValorValidator()]),
      });
  }
  limparCampos(): void {
    this.valorSaque = NaN;
  }
  valueFormatter(event: any) {
    let value = event.target.value;
    value = value.replace(/\D/g, '');
    value = parseInt(value, 10) / 100;

    if (!isNaN(value)) {
      const formattedValue =
        'R$ ' + value.toLocaleString('pt-BR', { minimumFractionDigits: 2 });
      this.saqueForm.controls['valorSaque'].setValue(formattedValue);
    } else {
      this.saqueForm.controls['valorSaque'].setValue('R$ 0,00');
    }
  }
  validarCampos(): boolean {
    let valorSaque = parseInt(this.saqueForm.value.valorSaque);
    if (valorSaque >= 10) {
      return true;
    } else {
      return false;
    }
  }

  setInputValue(idInput: string, value: string) {
    const input = document.getElementById(idInput) as HTMLInputElement
    input.value = value
    this.saqueForm.controls['valorSaque'].setValue(value);
  }
  }
}
