import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ListaEstabelecimentoUsuarioComponent } from './lista-estabelecimento-usuario.component';

describe('ListaEstabelecimentoUsuarioComponent', () => {
  let component: ListaEstabelecimentoUsuarioComponent;
  let fixture: ComponentFixture<ListaEstabelecimentoUsuarioComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ListaEstabelecimentoUsuarioComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(ListaEstabelecimentoUsuarioComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
