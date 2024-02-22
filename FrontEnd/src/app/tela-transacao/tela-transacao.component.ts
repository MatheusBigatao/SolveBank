import { ReactiveFormsModule } from '@angular/forms';
import { Component, HostListener } from '@angular/core';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-tela-transacao',
  standalone: true,
  imports: [CommonModule, ReactiveFormsModule],
  templateUrl: './tela-transacao.component.html',
  styleUrl: './tela-transacao.component.css',
})
export class TelaTransacaoComponent {
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
