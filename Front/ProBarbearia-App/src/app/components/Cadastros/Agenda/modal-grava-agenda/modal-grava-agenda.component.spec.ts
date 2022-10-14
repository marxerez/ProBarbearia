import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalGravaAgendaComponent } from './modal-grava-agenda.component';

describe('ModalGravaAgendaComponent', () => {
  let component: ModalGravaAgendaComponent;
  let fixture: ComponentFixture<ModalGravaAgendaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalGravaAgendaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ModalGravaAgendaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
