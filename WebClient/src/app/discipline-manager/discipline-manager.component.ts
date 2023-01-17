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

  ngOnInit(): void { }


  @Input() selected: DisciplineModel;
  id: string = "";
  name: string = "";
  lectorId: string = "";
  lectorFullName: string = "";
  groupId: string = "";
  groupName: string = "";
  semester: number = 0;
  assistantsIds: string[] = [];
  assistantsFullNames: string[] = [];
  @ViewChild(DisciplineComboBoxComponent) disciplineViewChild!: DisciplineComboBoxComponent;
  @ViewChild('lector') lectorViewChild!: TeacherComboBoxComponent;
  @ViewChild('newAssistant') assistantViewChild!: TeacherComboBoxComponent;
  @ViewChild(GroupComboBoxComponent) groupViewChild!: GroupComboBoxComponent;
  loading: boolean = false;
  
  importDiscipline(discipline: DisciplineModel) {
    this.selected = discipline;
    this.id = discipline.id;
    this.name = discipline.name;
    this.lectorId = discipline.lectorId;
    this.lectorFullName = discipline.lectorFullName;

    this.lectorViewChild.showById(this.lectorId);

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

  deleteAssistant(index: number) {
    this.assistantsFullNames.splice(index, 1);
    this.assistantsIds.splice(index, 1);
  }

  addAssistant() {
    const fullname = this.assistantViewChild.selectedTeacher.surname + " " + this.assistantViewChild.selectedTeacher.name + " " + this.assistantViewChild.selectedTeacher.midname;
    this.assistantsFullNames.push(fullname);
    this.assistantsIds.push(this.assistantViewChild.selectedTeacher.id);
  }

  addDiscipline() {
    let discipline: DisciplineModel = {
      name: this.name,
      id: "",
      lectorId: this.lectorViewChild.selectedTeacher.id,
      lectorFullName: "",
      groupId: this.groupViewChild.selectedGroup.id,
      groupName: "",
      semester: this.semester,
      assistantsIds: this.assistantsIds,
        assistantsFullNames: []
    }
    this.loading = true;
    this._disciplineService.Add(discipline).subscribe(() => this.loading = false);

  }
  deleteDiscipline() {
    this.loading = true;
    this._disciplineService.Delete(this.selected).subscribe(() => this.loading = false);
  }
  
  updateDiscipline() {
    let discipline: DisciplineModel = {
      name: this.name,
      id: this.id,
      lectorId: this.lectorViewChild.selectedTeacher.id,
      lectorFullName: "",
      groupId: this.groupViewChild.selectedGroup.id,
      groupName: "",
      semester: this.semester,
      assistantsIds: this.assistantsIds,
        assistantsFullNames: []
    }
    this.loading = true;
    this._disciplineService.Update(discipline).subscribe(() => this.loading = false);
  }
}

