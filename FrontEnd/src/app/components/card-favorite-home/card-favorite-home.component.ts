import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-card-favorite-home',
  standalone: true,
  imports: [],
  templateUrl: './card-favorite-home.component.html',
  styleUrl: './card-favorite-home.component.css'
})
export class CardFavoriteHomeComponent {
  @Input() title: string = '';
  @Input() image: string = '';
  @Input() altImage: string = '';
}
