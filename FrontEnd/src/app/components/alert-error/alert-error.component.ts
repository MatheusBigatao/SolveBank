import { Component, Input } from '@angular/core';
import { AlertCustom } from '../../models/Alert/AlertCustom';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-alert-error',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './alert-error.component.html',
  styleUrl: './alert-error.component.css'
})
export class AlertErrorComponent {
  @Input()
  alertDetails: AlertCustom | null = null
  @Input()
  alertOpen: boolean = false;
}
