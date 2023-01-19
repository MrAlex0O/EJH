import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { GenericComboBoxComponent } from '../generic-combo-box/generic-combo-box.component';
import { DisciplineModel } from '../_models/disciplineModel';
import { LessonModel } from '../_models/lessonModel';
import { LessonTypeModel } from '../_models/lessonTypeModel';
import { DisciplineService } from '../_services/discipline.service';
import { LessonTypeService } from '../_services/lesson-type.service';
import { LessonService } from '../_services/lesson.service';

@Component({
  selector: 'app-lesson-manager',
  templateUrl: './lesson-manager.component.html',
  styleUrls: ['./lesson-manager.component.css']
})
export class LessonManagerComponent implements OnInit {

  @Input() selected: LessonModel;
  @ViewChild('lessonTypeSelector') lessonTypeViewChild!: GenericComboBoxComponent;
  @ViewChild('disciplineSelector') disciplineViewChild!: GenericComboBoxComponent;
  lessonTypes: LessonTypeModel[] = [];
  disciplines: DisciplineModel[] = [];
  lessons: LessonModel[] = [];
  disciplineId: string;
  lessonTypeId: string;
  lessonRenderFunction = (item: LessonModel) => { return `${item.disciplineName} ${item.groupName} ${item.date} ${item.lessonType}`; }
  disciplineRenderFunction = (item: DisciplineModel) => { return `${item.name} ${item.groupName}`; }
  lessonTypeRenderFunction = (item: LessonTypeModel) => { return `${item.name}`; }

  date = new FormControl(new Date());
  loading: boolean = false;

  constructor(private _lessonService: LessonService, private _disciplineService: DisciplineService, private _lessonTypeService: LessonTypeService) { }
  ngOnInit(): void {
    this._disciplineService.getAll().subscribe(disciplines => this.disciplines.push(...disciplines));
    this._lessonService.getAll().subscribe(lessons => this.lessons.push(...lessons));
    this._lessonTypeService.getAll().subscribe(lessonTypes => this.lessonTypes.push(...lessonTypes));
  }
  add() {
    let lesson: LessonModel = {
      id: '',
      disciplineId: this.disciplineId,
        disciplineName: '',
        groupId: '',
        groupName: '',
        lectorId: '',
        lectorFullName: '',
        assistantsIds: [],
      assistantsFullNames: [],
      lessonTypeId: this.lessonTypeId,
      lessonType: '',
      date: ConvertDate(<Date>this.date.value),
      sequenceNumber: 0
    }
    this.loading = true;
    this._lessonService.Add(lesson).subscribe(() => this.loading = false);
  }
  update() {
    const dateString = (<Date>this.date.value).toLocaleString();
    let lesson: LessonModel = {
      id: this.selected.id,
      disciplineId: this.disciplineId,
      disciplineName: '',
      groupId: '',
      groupName: '',
      lectorId: '',
      lectorFullName: '',
      assistantsIds: [],
      assistantsFullNames: [],
      lessonTypeId: this.lessonTypeId,
      lessonType: '',
      date: ConvertDate(<Date>this.date.value),
      sequenceNumber: 0
    }
    this.loading = true;
    this._lessonService.Update(lesson).subscribe(() => this.loading = false);
  }
  delete() {
    this.loading = true;
    this._lessonService.Delete(this.selected).subscribe(() => this.loading = false);
  }
  importLesson(lesson: LessonModel) {
    this.selected = lesson;
    this.disciplineId = lesson.disciplineId;
    this.lessonTypeId = lesson.lessonTypeId;
    this.disciplineViewChild.showById(lesson.disciplineId);
    this.lessonTypeViewChild.showById(lesson.lessonTypeId);
    this.date.setValue(new Date(lesson.date));
  }  
  importDiscipline(discipline: DisciplineModel) {
    this.disciplineId = discipline.id;
  }
  importLessonType(lessonType: LessonTypeModel) {
    this.lessonTypeId = lessonType.id;
  }
}

function ConvertDate(date: Date): string {
  let month = (date.getMonth()+1).toString();
  let day = date.getDate().toString();
  if (day.length == 1) day = '0'+day;
  if (month.length == 1) month = '0' + month;
  const year = date.getFullYear();
  const result = `${year}-${month}-${day}T12:00:00.000`;
  return result;
}
