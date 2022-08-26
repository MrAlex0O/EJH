import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentComboBoxComponent } from './student-combo-box.component';

describe('StudentComboBoxComponent', () => {
  let component: StudentComboBoxComponent;
  let fixture: ComponentFixture<StudentComboBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentComboBoxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StudentComboBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
