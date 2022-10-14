import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GerenciaAgendaComponent } from './gerencia-agenda.component';

describe('GerenciaAgendaComponent', () => {
  let component: GerenciaAgendaComponent;
  let fixture: ComponentFixture<GerenciaAgendaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GerenciaAgendaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(GerenciaAgendaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
