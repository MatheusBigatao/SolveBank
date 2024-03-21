import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExternalWithdrawComponent } from './withdraw.component';

describe('WithdrawComponent', () => {
  let component: ExternalWithdrawComponent;
  let fixture: ComponentFixture<ExternalWithdrawComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExternalWithdrawComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExternalWithdrawComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
