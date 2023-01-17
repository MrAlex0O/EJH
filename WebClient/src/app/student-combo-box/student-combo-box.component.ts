import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { StudentModel } from '../_models/studentModel';
import { StudentService } from '../_services/student.service';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-student-combo-box',
  templateUrl: './student-combo-box.component.html',
  styleUrls: ['./student-combo-box.component.css']
})
export class StudentComboBoxComponent implements OnInit, OnChanges {
  students: StudentModel[] = [];
  public selectedStudent: StudentModel;
  public student: StudentModel;
  @Output() myEvent = new EventEmitter<StudentModel>();
  @Input() loading: boolean = false;

  constructor(public _studentService: StudentService) { }

  ngOnInit(): void {
  }
  public showById(id: string) {
    this.selectedStudent = <StudentModel>this.students.find(t => t.id == id);
  }
  ngOnChanges() {
    if (this.loading == false) {
      this.upload();
    }
  }
  public upload(): void {
    this.students.length = 0;
    this._studentService.getAll().subscribe(students => this.students.push(...students));
  }
  exportValue() {
    this.myEvent.emit(this.selectedStudent);
  }
}
