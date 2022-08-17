import { ComponentFixture, TestBed } from '@angular/core/testing';

import { GroupComboBoxComponent } from './group-combo-box.component';

describe('GroupComboBoxComponent', () => {
  let component: GroupComboBoxComponent;
  let fixture: ComponentFixture<GroupComboBoxComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ GroupComboBoxComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(GroupComboBoxComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
