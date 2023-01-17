import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { LessonTypeModel } from '../_models/lessonTypeModel';
import { LessonTypeService } from '../_services/lesson-type.service';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-lesson-type-combo-box',
  templateUrl: './lesson-type-combo-box.component.html',
  styleUrls: ['./lesson-type-combo-box.component.css']
})
export class LessonTypeComboBoxComponent implements OnInit, OnChanges {
  public lessonTypes: LessonTypeModel[] = [];
  public selectedLessonType: LessonTypeModel;
  @Output() myEvent = new EventEmitter<LessonTypeModel>();
  @Input() loading: boolean = false;
  public lessonTypeControl = new FormControl<LessonTypeModel>(this.lessonTypes[0], Validators.required);

  constructor(public _lessonTypeService: LessonTypeService) { }

  ngOnInit(): void { }

  ngOnChanges() {
    if (this.loading == false) {
      this.upload();
    }
  }

  public upload(): void {
    this.lessonTypes.length = 0;
    this._lessonTypeService.getAll().subscribe(lessonTypes => this.lessonTypes.push(...lessonTypes));
  }

  exportValue() {
    this.myEvent.emit(<LessonTypeModel>this.lessonTypeControl.value);
  }

  public showById(id: string) {
    this.selectedLessonType = <LessonTypeModel>this.lessonTypes.find(g => g.id == id);
  }
}
