import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { StatusOnLesson } from '../_models/statusOnLesson';
import { StudentModel } from '../_models/studentModel';

@Component({
  selector: 'app-student-visit',
  templateUrl: './student-visit.component.html',
  styleUrls: ['./student-visit.component.css']
})
export class StudentVisitComponent implements OnInit, OnChanges {
  student: StudentModel;
  @Output() myEvent = new EventEmitter<StatusOnLesson>();
  @Input() loading: boolean = false;
  statuses: StatusOnLesson[] = [];
  public selectedStatus: StatusOnLesson;
  constructor() { }

  ngOnInit(): void {
  }
  ngOnChanges() {

  }
  public upload(student: StudentModel, statuses: StatusOnLesson[]): void {
    this.student = student;
    this.statuses.length = 0;
    this.statuses.push(...statuses);
  }

  exportValue() {
    this.myEvent.emit(this.selectedStatus);
  }
}
