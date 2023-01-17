import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { TeacherModel } from '../_models/teacherModel';
import { TeacherService } from '../_services/teacher.service';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-teacher-combo-box',
  templateUrl: './teacher-combo-box.component.html',
  styleUrls: ['./teacher-combo-box.component.css']
})
export class TeacherComboBoxComponent implements OnInit, OnChanges {
  public teachers: TeacherModel[] = [];
  public selectedTeacher: TeacherModel;
  @Output() myEvent = new EventEmitter<TeacherModel>();
  @Input() loading: boolean = false;
  public teacherControl = new FormControl<TeacherModel>(this.teachers[0], Validators.required);

  constructor(private _teacherService: TeacherService) { }

  ngOnInit(): void { }

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
    this.myEvent.emit(<TeacherModel>this.teacherControl.value);
  }

  public showById(id: string) {
    this.selectedTeacher = <TeacherModel>this.teachers.find(g => g.id == id);
  }
}
