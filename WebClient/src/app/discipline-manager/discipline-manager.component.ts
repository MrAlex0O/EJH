import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { DisciplineComboBoxComponent } from '../discipline-combo-box/discipline-combo-box.component';
import { GroupComboBoxComponent } from '../group-combo-box/group-combo-box.component';
import { TeacherComboBoxComponent } from '../teacher-combo-box/teacher-combo-box.component';
import { DisciplineModel } from '../_models/disciplineModel';
import { GroupModel } from '../_models/groupModel';
import { TeacherModel } from '../_models/teacherModel';
import { DisciplineService } from '../_services/discipline.service';

@Component({
  selector: 'app-discipline-manager',
  templateUrl: './discipline-manager.component.html',
  styleUrls: ['./discipline-manager.component.css']
})
export class DisciplineManagerComponent implements OnInit {

  constructor(private _disciplineService: DisciplineService) { }

  ngOnInit(): void {
    /*this.name = this.selected.name;
    this.surname = this.selected.surname;
    this.midname = this.selected.midname;
    this.email = this.selected.email;
    this.address = this.selected.address;
    this.phoneNumber = this.selected.phoneNumber;*/
  }


  @Input() selected: DisciplineModel;
  id: string = "";
  name: string = "";
  lectorId: string = "";
  lectorFullName: string = "";
  groupId: string = "";
  groupName: string = "";
  semester: number = 0;
  assistantsIds: string[];
  assistantsFullNames: string[];
  @ViewChild(DisciplineComboBoxComponent) disciplineViewChild!: DisciplineComboBoxComponent;
  @ViewChild(TeacherComboBoxComponent) lectorlineViewChild!: TeacherComboBoxComponent;
  @ViewChild(GroupComboBoxComponent) groupViewChild!: GroupComboBoxComponent;
  loading: boolean = false;
  
  importDiscipline(discipline: DisciplineModel) {
    this.selected = this.disciplineViewChild.selectedDiscipline;
    this.id = discipline.id;
    this.name = discipline.name;
    this.lectorId = discipline.lectorId;
    this.lectorFullName = discipline.lectorFullName;

    this.lectorlineViewChild.showById(this.lectorId);

    this.groupId = discipline.groupId;
    this.groupName = discipline.groupName;

    this.groupViewChild.showById(this.groupId);

    this.semester = discipline.semester;
    this.assistantsIds = discipline.assistantsIds;
    this.assistantsFullNames = discipline.assistantsFullNames;
    console.log(discipline);
  }
  importLector(teacher: TeacherModel) {

  }
  importGroup(group: GroupModel) {

  }
  /*
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
  }*/
}

