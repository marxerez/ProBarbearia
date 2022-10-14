/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { ServicoProfissionalService } from './ServicoProfissional.service';

describe('Service: ServicoProfissional', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [ServicoProfissionalService]
    });
  });

  it('should ...', inject([ServicoProfissionalService], (service: ServicoProfissionalService) => {
    expect(service).toBeTruthy();
  }));
});
