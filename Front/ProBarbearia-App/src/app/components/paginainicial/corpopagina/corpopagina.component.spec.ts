import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CorpopaginaComponent } from './corpopagina.component';

describe('CorpopaginaComponent', () => {
  let component: CorpopaginaComponent;
  let fixture: ComponentFixture<CorpopaginaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CorpopaginaComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CorpopaginaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
