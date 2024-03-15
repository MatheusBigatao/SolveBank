import { Component } from '@angular/core';
import { MenuHomeComponent } from '../../components/menu-home/menu-home.component';

@Component({
  selector: 'app-external-home',
  standalone: true,
  imports: [MenuHomeComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class ExternalHomeComponent {

}
