import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CardFavoriteHomeComponent } from './card-favorite-home.component';

describe('CardFavoriteHomeComponent', () => {
  let component: CardFavoriteHomeComponent;
  let fixture: ComponentFixture<CardFavoriteHomeComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [CardFavoriteHomeComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(CardFavoriteHomeComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
