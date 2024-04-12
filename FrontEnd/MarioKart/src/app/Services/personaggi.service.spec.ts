import { TestBed } from '@angular/core/testing';

import { PersonaggiService } from './personaggi.service';

describe('PersonaggiService', () => {
  let service: PersonaggiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PersonaggiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
