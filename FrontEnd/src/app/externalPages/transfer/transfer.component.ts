import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuHomeComponent } from '../../components/menu-home/menu-home.component';
import {
  FormControl,
  FormGroup,
  ReactiveFormsModule,
  Validators,
} from '@angular/forms';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-transfer',
  standalone: true,
  templateUrl: './transfer.component.html',
  styleUrl: './transfer.component.css',
  imports: [CommonModule, MenuHomeComponent, ReactiveFormsModule, RouterModule],
})
export class ExternalTransferComponent {
  transferForm: FormGroup;

  constructor() {
    this.transferForm = new FormGroup({
      beneficiary: new FormControl('', [
      ]),
      sourceAccount: new FormControl('', [
        Validators.required,
        Validators.pattern(/^\d{8}\-\d{1}$/),
      ]),
      destinationBranch: new FormControl('', [
        Validators.required,
        Validators.pattern(/^\d{4}$/),
      ]),
      destinationAccount: new FormControl('', [
        Validators.required,
        Validators.pattern(/^\d{8}\-\d{1}$/),
      ]),
      value: new FormControl('', Validators.required),
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
}
