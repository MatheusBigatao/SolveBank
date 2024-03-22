import { Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-withdraw',
  standalone: true,
  imports: [RouterModule, FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './withdraw.component.html',
  styleUrl: './withdraw.component.css',
})
export class ExternalWithdrawComponent {
  value: string = '';
  formulario: any;
  limparCampos(): void {
    this.value = '';
  }
}
