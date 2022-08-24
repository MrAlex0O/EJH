import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { TeacherModel } from '../_models/teacherModel';
import { TeacherService } from '../_services/teacher.service';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-teacher-combo-box',
  templateUrl: './teacher-combo-box.component.html',
  styleUrls: ['./teacher-combo-box.component.css']
})
export class TeacherComboBoxComponent implements OnInit, OnChanges {
  teachers: TeacherModel[] = [];
  public selectedTeacher: TeacherModel;
  public teacher: TeacherModel;
  @Output() myEvent = new EventEmitter<TeacherModel>();
  @Input() loading: boolean = false;

  constructor(public _teacherService: TeacherService) { }

  ngOnInit(): void {

    this._teacherService.getAll().subscribe(teachers => this.teachers = teachers);

  }
  public showById(id: string) {
    this.selectedTeacher = <TeacherModel>this.teachers.find(t => t.id == id);
  }
  ngOnChanges() {
    if (this.loading == false) {
      this.upload();
    }
  }
  public upload(): void {
    this.teachers.length = 0;
    this._teacherService.getAll().subscribe(teachers => this.teachers.push(...teachers));
  }
  exportValue() {
    this.myEvent.emit(this.selectedTeacher);
  }
}
