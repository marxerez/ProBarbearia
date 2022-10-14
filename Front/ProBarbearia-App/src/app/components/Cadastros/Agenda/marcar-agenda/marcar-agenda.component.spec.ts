import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MarcarAgendaComponent } from './marcar-agenda.component';

describe('MarcarAgendaComponent', () => {
  let component: MarcarAgendaComponent;
  let fixture: ComponentFixture<MarcarAgendaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MarcarAgendaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(MarcarAgendaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
