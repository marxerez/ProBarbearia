/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EstabelecimentoUsuarioService } from './EstabelecimentoUsuario.service';

describe('Service: EstabelecimentoUsuario', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EstabelecimentoUsuarioService]
    });
  });

  it('should ...', inject([EstabelecimentoUsuarioService], (service: EstabelecimentoUsuarioService) => {
    expect(service).toBeTruthy();
  }));
});
