import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisciplineComboBoxComponent } from './discipline-combo-box.component';

describe('DisciplinesComboBoxComponent', () => {
  let component: DisciplineComboBoxComponent;
  let fixture: ComponentFixture<DisciplineComboBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisciplineComboBoxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DisciplineComboBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
