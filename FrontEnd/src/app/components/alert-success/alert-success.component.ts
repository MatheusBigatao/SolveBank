import { Component, Input } from '@angular/core';
import { AlertCustom } from '../../models/Alert/AlertCustom';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-alert-success',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './alert-success.component.html',
  styleUrl: './alert-success.component.css'
})
export class AlertSuccessComponent { 
  @Input()
  alertDetails: AlertCustom | null = null
  @Input()
  alertOpen: boolean = false;
}
