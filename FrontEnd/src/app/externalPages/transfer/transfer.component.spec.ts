import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ExternalTransferComponent } from './transfer.component';

describe('TransferComponent', () => {
  let component: ExternalTransferComponent;
  let fixture: ComponentFixture<ExternalTransferComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ExternalTransferComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(ExternalTransferComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
