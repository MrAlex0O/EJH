import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { FormControl } from '@angular/forms';
import { DisciplineComboBoxComponent } from '../discipline-combo-box/discipline-combo-box.component';
import { LessonTypeComboBoxComponent } from '../lesson-type-combo-box/lesson-type-combo-box.component';
import { LessonModel } from '../_models/lessonModel';
import { LessonService } from '../_services/lesson.service';

@Component({
  selector: 'app-lesson-manager',
  templateUrl: './lesson-manager.component.html',
  styleUrls: ['./lesson-manager.component.css']
})
export class LessonManagerComponent implements OnInit {

  constructor(private _lessonService: LessonService) { }
  @Input() selected: LessonModel;
  @ViewChild(LessonTypeComboBoxComponent) lessonTypeViewChild!: LessonTypeComboBoxComponent;
  @ViewChild(DisciplineComboBoxComponent) disciplineViewChild!: DisciplineComboBoxComponent;
  date = new FormControl(new Date());
  loading: boolean = false;
  ngOnInit(): void {
  }
  add() {
    let lesson: LessonModel = {
      id: '',
      disciplineId: this.disciplineViewChild.selectedDiscipline.id,
        disciplineName: '',
        groupId: '',
        groupName: '',
        lectorId: '',
        lectorFullName: '',
        assistantsIds: [],
      assistantsFullNames: [],
      lessonTypeId: this.lessonTypeViewChild.selectedLessonType.id,
      lessonType: '',
      date: this.date.value,
      sequenceNumber: 0
    }
    this.loading = true;
    this._lessonService.Add(lesson).subscribe(() => this.loading = false);
  }
  update() {
    let lesson: LessonModel = {
      id: this.selected.id,
      disciplineId: this.disciplineViewChild.selectedDiscipline.id,
      disciplineName: '',
      groupId: '',
      groupName: '',
      lectorId: '',
      lectorFullName: '',
      assistantsIds: [],
      assistantsFullNames: [],
      lessonTypeId: this.lessonTypeViewChild.selectedLessonType.id,
      lessonType: '',
      date: this.date.value,
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
    this.disciplineViewChild.showById(lesson.disciplineId);
    this.lessonTypeViewChild.showById(lesson.lessonTypeId);
    this.date.setValue(lesson.date);
  }  
  importDiscipline(a: any) { }
  importLessonType(a: any) { }
}
