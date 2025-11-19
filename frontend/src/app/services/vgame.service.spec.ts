import { TestBed } from '@angular/core/testing';
import { VGameService } from './vgame.service';

describe('Vgame', () => {
  let service: VGameService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(VGameService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
