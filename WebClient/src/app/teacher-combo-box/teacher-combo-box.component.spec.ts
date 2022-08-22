import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TeacherComboBoxComponent } from './teacher-combo-box.component';

describe('TeacherComboBoxComponent', () => {
  let component: TeacherComboBoxComponent;
  let fixture: ComponentFixture<TeacherComboBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TeacherComboBoxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(TeacherComboBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
