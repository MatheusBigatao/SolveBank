import { Component, Input } from '@angular/core';
import { AlertCustom } from '../../models/Alert/AlertCustom';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-alert-info',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './alert-info.component.html',
  styleUrl: './alert-info.component.css'
})
export class AlertInfoComponent {
  @Input()
  alertDetails: AlertCustom | null = null
  @Input()
  alertOpen: boolean = false;
}
