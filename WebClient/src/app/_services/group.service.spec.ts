import { TestBed } from '@angular/core/testing';

import { GroupService } from './group.service';

describe('GroupServiceService', () => {
  let service: GroupService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(GroupService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
