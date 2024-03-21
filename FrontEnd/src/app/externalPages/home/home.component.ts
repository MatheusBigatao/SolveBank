import { Component } from '@angular/core';
import { MenuHomeComponent } from '../../components/menu-home/menu-home.component';
import { RouterModule } from '@angular/router';

@Component({
  selector: 'app-external-home',
  standalone: true,
  imports: [MenuHomeComponent, RouterModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class ExternalHomeComponent {
  
  //Tratamento de erro 401
  // error: err => {
  //   if (err.status === 401) {
  //     localStorage.removeItem('userLogged');
  //     this.route.navigateByUrl("/login");
  //   }
  
}
