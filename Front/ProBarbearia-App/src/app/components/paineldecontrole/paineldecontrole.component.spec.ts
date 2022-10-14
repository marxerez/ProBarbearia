import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PaineldecontroleComponent } from './paineldecontrole.component';

describe('PaineldecontroleComponent', () => {
  let component: PaineldecontroleComponent;
  let fixture: ComponentFixture<PaineldecontroleComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PaineldecontroleComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PaineldecontroleComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
