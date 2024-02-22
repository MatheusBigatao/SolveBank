import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TelaTransacaoComponent } from './tela-transacao.component';

describe('TelaTransacaoComponent', () => {
  let component: TelaTransacaoComponent;
  let fixture: ComponentFixture<TelaTransacaoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [TelaTransacaoComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(TelaTransacaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
