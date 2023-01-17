import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { LessonModel } from '../_models/lessonModel';
import { LessonService } from '../_services/lesson.service';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-lesson-combo-box',
  templateUrl: './lesson-combo-box.component.html',
  styleUrls: ['./lesson-combo-box.component.css']
})
export class LessonComboBoxComponent implements OnInit, OnChanges {
  lessons: LessonModel[] = [];
  public selectedLesson: LessonModel;
  @Output() myEvent = new EventEmitter<LessonModel>();
  @Input() loading: boolean = false;

  constructor(public _lessonService: LessonService) { }

  ngOnInit(): void {

  }

  public showById(id: string) {
    this.selectedLesson = <LessonModel>this.lessons.find(g => g.id == id);
  }
  ngOnChanges() {
    if (this.loading == false) {
      this.upload();
    }
  }
  public upload(): void {
    this.lessons.length = 0;
    this._lessonService.getAll().subscribe(lessons => this.lessons.push(...lessons));
  }
  exportValue() {
    this.myEvent.emit(this.selectedLesson);
  }
}
