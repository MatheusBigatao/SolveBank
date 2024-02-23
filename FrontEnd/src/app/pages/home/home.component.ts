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
  responsiveOptions: any[] | undefined;
  isSmallScreen: boolean = window.innerWidth < 1120;
  cards: any[] = []
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

  ngOnInit() {
    this.responsiveOptions = [
      {
        breakpoint: '1120px',
        numVisible: 2,
        numScroll: 1
      },
      {
        breakpoint: '991px',
        numVisible: 2,
        numScroll: 1
      },
      {
        breakpoint: '767px',
        numVisible: 3,
        numScroll: 1
      }
    ];
    this.cards = [
      {
        title: "Pix",
        image: "assets/Images/icon-pix.svg",
        altImage: "Pix Icon"
      },
      {
        title: "Transações",
        image: "assets/Images/icon-transfer.svg",
        altImage: "Transfer Icon"
      },
      {
        title: "Pagar",
        image: "assets/Images/icon-scan.svg",
        altImage: "Scan Icon"
      },
      {       
        title: "Comprovantes",
        image: "assets/Images/icon-file-text.svg",
        altImage: "File Text Icon"
      }      

    ]
  }




}

