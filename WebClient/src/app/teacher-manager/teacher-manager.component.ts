import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { TeacherComboBoxComponent } from '../teacher-combo-box/teacher-combo-box.component';
import { TeacherModel } from '../_models/teacherModel';
import { TeacherService } from '../_services/teacher.service'

@Component({
  selector: 'app-teacher-manager',
  templateUrl: './teacher-manager.component.html',
  styleUrls: ['./teacher-manager.component.css']
})
export class TeacherManagerComponent implements OnInit {

  constructor(private _teacherService: TeacherService) { }
  @Input() selected: TeacherModel;
  name: string = "";
  midname: string = "";
  surname: string = "";
  email: string = "";
  address: string = "";
  phoneNumber: string = "";
  @ViewChild(TeacherComboBoxComponent) viewChild!: TeacherComboBoxComponent;
  loading: boolean = false;

  ngOnInit(): void {
    this.name = this.selected.name;
    this.surname = this.selected.surname;
    this.midname = this.selected.midname;
    this.email = this.selected.email;
    this.address = this.selected.address;
    this.phoneNumber = this.selected.phoneNumber;
  }
  importValue(teacher: TeacherModel) {
    this.selected = teacher;
    this.name = teacher.name;
    this.surname = teacher.surname;
    this.midname = teacher.midname;
    this.email = teacher.email;
    this.address = teacher.address;
    this.phoneNumber = teacher.phoneNumber;
    console.log(teacher);
  }
  update() {
    this.loading = true;
    let teacher: TeacherModel = {
      name: this.name, id: this.selected.id, midname: this.midname,
      surname: this.surname,
      address: this.address,
      email: this.email,
      phoneNumber: this.phoneNumber
    }
    this._teacherService.Update(teacher).subscribe(() => this.loading = false);
  }
  add() {
    let teacher: TeacherModel = {
      name: this.name, id: "", midname: this.midname,
      surname: this.surname,
      address: this.address,
      email: this.email,
      phoneNumber: this.phoneNumber
    }
    this.loading = true;
    this._teacherService.Add(teacher).subscribe(() => this.loading = false);
  }
  delete() {
    this.loading = true;
    this._teacherService.Delete(this.selected).subscribe(() => this.loading = false);
  }

}
