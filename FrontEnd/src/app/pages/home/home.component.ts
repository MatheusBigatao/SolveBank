import { Component, HostListener } from '@angular/core';
import { MenuHomeComponent } from '../../components/menu-home/menu-home.component';
import { NavbarComponent } from '../../components/navbar/navbar.component';
import { CardFavoriteHomeComponent } from '../../components/card-favorite-home/card-favorite-home.component';
import { CarouselModule } from 'primeng/carousel';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [MenuHomeComponent, NavbarComponent, CardFavoriteHomeComponent, CarouselModule],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  
  isSmallScreen: boolean = window.innerWidth < 768;

  constructor() {
    this.checkScreenSize();
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    this.checkScreenSize();
  }

  checkScreenSize() {
    this.isSmallScreen = window.innerWidth < 768;
  }
} 

