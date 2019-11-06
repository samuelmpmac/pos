import { TestBed } from '@angular/core/testing';

import { PerfilAuthGuardService } from './perfil-auth-guard.service';

describe('PerfilAuthGuardService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PerfilAuthGuardService = TestBed.get(PerfilAuthGuardService);
    expect(service).toBeTruthy();
  });
});
