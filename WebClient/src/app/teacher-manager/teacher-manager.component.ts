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

  constructor(private _teacherService: TeacherService, private _router: Router) { }
  @Input() selected: TeacherModel = {
      id: "", name: "",
      midname: "",
      surname: "",
      address: "",
      email: "",
      phoneNumber: ""
  };
  name: string = "";
  midname: string = "";
  surname: string = "";
  email: string = "";
  address: string = "";
  phoneNumber: string = "";
  @ViewChild(TeacherComboBoxComponent)
  viewChild!: TeacherComboBoxComponent;
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
    this.selected = this.viewChild.selectedTeacher;
    this.name = this.viewChild.selectedTeacher.name;
    this.surname = this.viewChild.selectedTeacher.surname;
    this.midname = this.viewChild.selectedTeacher.midname;
    this.email = this.viewChild.selectedTeacher.email;
    this.address = this.viewChild.selectedTeacher.address;
    this.phoneNumber = this.viewChild.selectedTeacher.phoneNumber;
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
