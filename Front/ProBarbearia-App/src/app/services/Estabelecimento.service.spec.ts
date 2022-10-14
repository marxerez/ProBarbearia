/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { EstabelecimentoService } from './Estabelecimento.service';

describe('Service: Estabelecimento', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [EstabelecimentoService]
    });
  });

  it('should ...', inject([EstabelecimentoService], (service: EstabelecimentoService) => {
    expect(service).toBeTruthy();
  }));
});
