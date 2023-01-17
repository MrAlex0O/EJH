import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { GroupComboBoxComponent } from '../group-combo-box/group-combo-box.component';
import { StudentComboBoxComponent } from '../student-combo-box/student-combo-box.component';
import { GroupModel } from '../_models/groupModel';
import { StudentModel } from '../_models/studentModel';
import { StudentService } from '../_services/student.service'

@Component({
  selector: 'app-student-manager',
  templateUrl: './student-manager.component.html',
  styleUrls: ['./student-manager.component.css']
})
export class StudentManagerComponent implements OnInit {

  constructor(private _studentService: StudentService) { }
  @Input() selected: StudentModel;
  name: string = "";
  midname: string = "";
  surname: string = "";
  email: string = "";
  address: string = "";
  phoneNumber: string = "";
  group: GroupModel;
  @ViewChild(StudentComboBoxComponent) studentViewChild!: StudentComboBoxComponent;
  @ViewChild(GroupComboBoxComponent) groupViewChild!: GroupComboBoxComponent;
  loading: boolean = false;

  ngOnInit(): void {
    this.name = this.selected.name;
    this.surname = this.selected.surname;
    this.midname = this.selected.midname;
    this.email = this.selected.email;
    this.address = this.selected.address;
    this.phoneNumber = this.selected.phoneNumber;
  }
  importValue(student: StudentModel) {
    this.selected = student;
    this.name = student.name;
    this.surname = student.surname;
    this.midname = student.midname;
    this.email = student.email;
    this.address = student.address;
    this.phoneNumber = student.phoneNumber;
    this.groupViewChild.showById(student.groupId);
    console.log(student);
  }

  importGroup(group: GroupModel) {
    this.group = group;
  }
  update() {
    this.loading = true;
    let student: StudentModel = {
        name: this.name, id: this.selected.id, midname: this.midname,
        surname: this.surname,
        address: this.address,
        email: this.email,
      phoneNumber: this.phoneNumber,
      groupId: this.groupViewChild.selectedGroup.id,
        groupName: ""
    }
    this._studentService.Update(student).subscribe(() => this.loading = false);
  }
  add() {
    let student: StudentModel = {
        name: this.name, id: "", midname: this.midname,
        surname: this.surname,
        address: this.address,
        email: this.email,
        phoneNumber: this.phoneNumber,
      groupId: this.groupViewChild.selectedGroup.id,
        groupName: ""
    }
    this.loading = true;
    this._studentService.Add(student).subscribe(() => this.loading = false);
  }
  delete() {
    this.loading = true;
    this._studentService.Delete(this.selected).subscribe(() => this.loading = false);
  }

}
