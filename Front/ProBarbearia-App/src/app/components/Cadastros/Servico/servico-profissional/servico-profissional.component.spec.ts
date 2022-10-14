import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ServicoProfissionalComponent } from './servico-profissional.component';

describe('ServicoProfissionalComponent', () => {
  let component: ServicoProfissionalComponent;
  let fixture: ComponentFixture<ServicoProfissionalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ServicoProfissionalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ServicoProfissionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
