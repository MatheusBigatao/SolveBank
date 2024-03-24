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
  value: string = '';
  formulario: any;
  constructor() {}
  limparCampos(): void {
    this.value = '';
  }
}
