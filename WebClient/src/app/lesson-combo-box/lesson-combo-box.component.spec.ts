import { ComponentFixture, TestBed } from '@angular/core/testing';

import { LessonComboBoxComponent } from './lesson-combo-box.component';

describe('LessonComboBoxComponent', () => {
  let component: LessonComboBoxComponent;
  let fixture: ComponentFixture<LessonComboBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ LessonComboBoxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(LessonComboBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
