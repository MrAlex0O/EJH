import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonTypeComboBoxComponent } from './lesson-type-combo-box.component';

describe('LessonTypeComboBoxComponent', () => {
  let component: LessonTypeComboBoxComponent;
  let fixture: ComponentFixture<LessonTypeComboBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LessonTypeComboBoxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LessonTypeComboBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
