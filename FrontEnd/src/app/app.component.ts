import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterOutlet } from '@angular/router';
import { AlertSuccessComponent } from './components/alert-success/alert-success.component';
import { AlertInfoComponent } from './components/alert-info/alert-info.component';
import { AlertErrorComponent } from './components/alert-error/alert-error.component';

@Component({
  selector: 'app-root',
  standalone: true,
  templateUrl: './app.component.html',
  styleUrl: './app.component.css',
  imports: [CommonModule, RouterOutlet],
})
export class AppComponent {
  title = 'FrontEnd';
}
