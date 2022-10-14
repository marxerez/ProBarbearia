import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditaProfissionalComponent } from './edita-profissional.component';

describe('EditaProfissionalComponent', () => {
  let component: EditaProfissionalComponent;
  let fixture: ComponentFixture<EditaProfissionalComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditaProfissionalComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditaProfissionalComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
