/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProfissionalHorarioService } from './ProfissionalHorario.service';

describe('Service: ProfissionalHorario', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProfissionalHorarioService]
    });
  });

  it('should ...', inject([ProfissionalHorarioService], (service: ProfissionalHorarioService) => {
    expect(service).toBeTruthy();
  }));
});
