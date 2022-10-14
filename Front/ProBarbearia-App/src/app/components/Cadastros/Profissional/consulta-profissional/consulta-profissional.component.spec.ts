import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ConsultaProfissionalComponent } from './consulta-profissional.component';

describe('ConsultaProfissionalComponent', () => {
  let component: ConsultaProfissionalComponent;
  let fixture: ComponentFixture<ConsultaProfissionalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ConsultaProfissionalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ConsultaProfissionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
