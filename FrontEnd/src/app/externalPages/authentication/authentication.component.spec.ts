import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExternalAuthenticationComponent } from './authentication.component';

describe('ExternalAuthenticationComponent', () => {
  let component: ExternalAuthenticationComponent;
  let fixture: ComponentFixture<ExternalAuthenticationComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExternalAuthenticationComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExternalAuthenticationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
