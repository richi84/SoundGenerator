import { TestBed, inject } from '@angular/core/testing';

import { MusicGeneratorClientService } from './music-generator-client.service';

describe('MusicGeneratorClientService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [MusicGeneratorClientService]
    });
  });

  it('should be created', inject([MusicGeneratorClientService], (service: MusicGeneratorClientService) => {
    expect(service).toBeTruthy();
  }));
});
