import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MenuHomeDesktopComponent } from './menu-home-desktop.component';

describe('MenuHomeDesktopComponent', () => {
  let component: MenuHomeDesktopComponent;
  let fixture: ComponentFixture<MenuHomeDesktopComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [MenuHomeDesktopComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(MenuHomeDesktopComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
