/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ProfissionalService } from './Profissional.service';

describe('Service: Profissional', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ProfissionalService]
    });
  });

  it('should ...', inject([ProfissionalService], (service: ProfissionalService) => {
    expect(service).toBeTruthy();
  }));
});
