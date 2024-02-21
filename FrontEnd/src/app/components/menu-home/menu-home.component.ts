import { CommonModule } from '@angular/common';
import { Component, HostListener } from '@angular/core';

@Component({
  selector: 'app-menu-home',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './menu-home.component.html',
  styleUrl: './menu-home.component.css'
})
export class MenuHomeComponent {
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
