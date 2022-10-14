import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditaHorarioProfissionalComponent } from './edita-horario-profissional.component';

describe('EditaHorarioProfissionalComponent', () => {
  let component: EditaHorarioProfissionalComponent;
  let fixture: ComponentFixture<EditaHorarioProfissionalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditaHorarioProfissionalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditaHorarioProfissionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
