import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonManagerComponent } from './lesson-manager.component';

describe('LessonManagerComponent', () => {
  let component: LessonManagerComponent;
  let fixture: ComponentFixture<LessonManagerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LessonManagerComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LessonManagerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
