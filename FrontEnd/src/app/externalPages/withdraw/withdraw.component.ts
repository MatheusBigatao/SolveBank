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
  saqueValidacao: boolean = false


  constructor(private saqueServicos: SaqueService, private _router: Router) {
    this.saqueForm = new FormGroup({
      valorSaque: new FormControl('', [Validators.required]),
    });
  }
  limparCampos(): void {
    this.saqueForm.reset();
    this.saqueValidacao = false
  }
  valueFormatter(event: any) {
    let value = event.target.value;
    value = value.replace(/\D/g, '');
    value = parseInt(value, 10) / 100;
    this.saqueValidacao = parseFloat(value) >= 10 && parseFloat(value) <= 1500 && parseFloat(value) % 10 == 0 ? true : false
    if (!isNaN(value)) {
      const formattedValue =
        value.toLocaleString('pt-BR', { minimumFractionDigits: 2 });
      this.saqueForm.controls['valorSaque'].setValue(formattedValue);
    } else {
      this.saqueForm.controls['valorSaque'].setValue('R$ 0,00');
    }
  }
  validarCampos(): boolean {
    let valorSaque = parseInt(this.saqueForm.value.valorSaque);
    if (valorSaque >= 10 && valorSaque <= 1500) {
      return true;
    } else {
      return false;
    }
  }

  setInputValue(idInput: string, value: string) {
    const input = document.getElementById(idInput) as HTMLInputElement
    input.value = value
    this.saqueForm.controls['valorSaque'].setValue(value);
    let valorConfirm = this.parseFloatCustom(value);
    this.saqueValidacao = valorConfirm >= 10 && valorConfirm% 10 == 0 ? true : false
  }

  efetuarSaque(): void {
    let saque = this.saqueForm.value as SaqueDTO
    if (!this.saqueValidacao) {
      this.alertCustom = new AlertCustom("Erro: ", "É permitido efetuar um saque de no minimo R$ 10,00")
      this.loadingSpinner = false
      this.alertFailOpen = true;
      setTimeout(() => {
        this.alertFailOpen = false
      }, 3000)
      return
    }
    this.loadingSpinner = true
    saque.valorSaque = this.parseFloatCustom(saque.valorSaque.toString())
    this.saqueServicos.sacar(saque).subscribe(
      {
        next: res => {
          this.alertCustom = new AlertCustom("Sucesso: ", "Saque efetuado com sucesso")
          this.loadingSpinner = false
          this.alertSuccesOpen = true;
          setTimeout(() => {
            this.alertSuccesOpen = false
            this._router.navigateByUrl("/external/home")
          }, 4000)
        },
        error: err => {
          this.alertCustom = new AlertCustom("Erro: ", "Erro ao efetuar saque")
          this.loadingSpinner = false
          this.alertFailOpen = true;
          setTimeout(() => {
            this.alertFailOpen = false
          }, 5000)
          localStorage.removeItem('userLogged');
          this._router.navigateByUrl('/external/login');    
        }
      }
    )
  }

  parseFloatCustom(value: string) {
    value = value.replace(/\./g, '');
    value = value.replace(',', '.');
    let floatValue = parseFloat(value);
    return floatValue;
  }
}
