import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EditaEstabelecimentoComponent } from './edita-estabelecimento.component';

describe('EditaEstabelecimentoComponent', () => {
  let component: EditaEstabelecimentoComponent;
  let fixture: ComponentFixture<EditaEstabelecimentoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EditaEstabelecimentoComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EditaEstabelecimentoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
