import { TestBed } from '@angular/core/testing';

import { NormaOuControleService } from './norma-ou-controle.service';

describe('NormaOuControleService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: NormaOuControleService = TestBed.get(NormaOuControleService);
    expect(service).toBeTruthy();
  });
});
