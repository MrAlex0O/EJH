import { ComponentFixture, TestBed } from '@angular/core/testing';

import { DisciplinesComboBoxComponent } from './disciplines-combo-box.component';

describe('DisciplinesComboBoxComponent', () => {
  let component: DisciplinesComboBoxComponent;
  let fixture: ComponentFixture<DisciplinesComboBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ DisciplinesComboBoxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(DisciplinesComboBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
