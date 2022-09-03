import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StudentVisitComponent } from './student-visit.component';

describe('StudentVisitComponent', () => {
  let component: StudentVisitComponent;
  let fixture: ComponentFixture<StudentVisitComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ StudentVisitComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(StudentVisitComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
