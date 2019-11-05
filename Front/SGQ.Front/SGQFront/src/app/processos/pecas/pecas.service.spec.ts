import { TestBed } from '@angular/core/testing';

import { PecasService } from './pecas.service';

describe('PecasService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PecasService = TestBed.get(PecasService);
    expect(service).toBeTruthy();
  });
});
