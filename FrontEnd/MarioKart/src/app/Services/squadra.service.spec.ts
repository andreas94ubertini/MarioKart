import { TestBed } from '@angular/core/testing';

import { SquadraService } from './squadra.service';

describe('SquadraService', () => {
  let service: SquadraService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(SquadraService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
