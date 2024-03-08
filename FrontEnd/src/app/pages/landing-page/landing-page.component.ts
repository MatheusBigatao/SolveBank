import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { Router, RouterModule } from '@angular/router';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [CommonModule, RouterModule],
  templateUrl: './landing-page.component.html',
  styleUrls: ['./landing-page.component.css'],
})
export class LandingPageComponent {
  constructor(private _route: Router) {}
  carouselItems = [
    {
      styledTitle: 'Solve',
      normalTitle: 'Bank',
      descriptionLogo: 'Onde cada transação é uma solução para o seu sucesso!',
      content: '../../../assets/Images/principal-icon 1.png',
      alt: 'Logo SolveBank',
      contentType: 'image',
    },
    {
      title: 'Multitelas, múltiplos lugares',
      descriptionImage:
        'Descubra um banco repleto de oportunidades em cada tela. Explore, invista e realize seus objetivos financeiros de onde estiver.',
      content: '../../../assets/Images/Home-page-MultTelas 1.png',
      contentType: 'image2',
    },
    {
      title: 'Tudo o que você precisa em um só lugar',
      description:
        'Bem-vindo(a) à SolveBank! Estamos aqui para simplificar sua vida financeira. Acesse sua conta, faça pagamentos, acompanhe seus gastos e muito mais, tudo em um único aplicativo fácil de usar.',
      content: 'bi bi-coin',
      contentType: 'icon',
    },
    {
      title: 'Segurança em primeiro lugar',
      description:
        'Sua segurança é nossa prioridade máxima. Conte conosco para proteger suas informações financeiras com tecnologias avançadas de segurança.',
      content: 'bi bi-shield-check',
      contentType: 'icon',
    },
    {
      title: 'Seu futuro financeiro começa aqui',
      description:
        'Comece sua jornada financeira. Estamos aqui para ajudá-lo a dar os primeiros passos rumo à estabilidade financeira. Juntos, vamos construir um futuro sólido e seguro.',
      content: 'bi bi-clipboard-data',
      contentType: 'icon',
    },
  ];

  signUp() {
    this._route.navigate(['/signUp']);
  }

  login() {
    this._route.navigate(['/login']);
  }
}
