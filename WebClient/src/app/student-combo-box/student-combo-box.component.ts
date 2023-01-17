import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { StudentModel } from '../_models/studentModel';
import { StudentService } from '../_services/student.service';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-student-combo-box',
  templateUrl: './student-combo-box.component.html',
  styleUrls: ['./student-combo-box.component.css']
})
export class StudentComboBoxComponent implements OnInit, OnChanges {
  public students: StudentModel[] = [];
  public selectedStudent: StudentModel;
  @Output() myEvent = new EventEmitter<StudentModel>();
  @Input() loading: boolean = false;
  public studentControl = new FormControl<StudentModel>(this.students[0], Validators.required);

  constructor(private _studentService: StudentService) { }

  ngOnInit(): void { }

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
    this.myEvent.emit(<StudentModel>this.studentControl.value);
  }

  public showById(id: string) {
    this.selectedStudent = <StudentModel>this.students.find(g => g.id == id);
  }
}
