import { ReactiveFormsModule } from '@angular/forms';
import { Component, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavbarComponent } from '../components/navbar/navbar.component';
import { MenuHomeComponent } from '../components/menu-home/menu-home.component';
import { MenuHomeDesktopComponent } from '../components/menu-home-desktop/menu-home-desktop.component';

@Component({
  selector: 'app-tela-transacao',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule, NavbarComponent, MenuHomeComponent, MenuHomeDesktopComponent],
  templateUrl: './tela-transacao.component.html',
  styleUrl: './tela-transacao.component.css',
})
export class TelaTransacaoComponent {
  isSmallScreen: boolean = window.innerWidth < 1120;

  constructor() {
    this.checkScreenSize();
  }

  @HostListener('window:resize', ['$event'])
  onResize(event: any) {
    this.checkScreenSize();
  }

  checkScreenSize() {
    this.isSmallScreen = window.innerWidth < 1120;
  }
}
