import { Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { DisciplineModel } from '../_models/disciplineModel';
import { DisciplineService } from '../_services/discipline.service';

@Component({
  selector: 'app-discipline-combo-box',
  templateUrl: './discipline-combo-box.component.html',
  styleUrls: ['./discipline-combo-box.component.css']
})
export class DisciplineComboBoxComponent implements OnInit, OnChanges {
  public disciplines: DisciplineModel[] = [];
  public selectedDiscipline: DisciplineModel;
  @Output() myEvent = new EventEmitter<DisciplineModel>();
  @Input() loading: boolean = false;
  public disciplineControl = new FormControl<DisciplineModel>(this.disciplines[0], Validators.required);

  constructor(private _disciplineService: DisciplineService) { }

  ngOnInit(): void { }

  ngOnChanges() {
    if (this.loading == false) {
      this.upload();
    }
  }

  public upload(): void {
    this.disciplines.length = 0;
    this._disciplineService.getAll().subscribe(disciplines => this.disciplines.push(...disciplines));
  }

  exportValue() {
    this.myEvent.emit(<DisciplineModel>this.disciplineControl.value);
  }

  showById(id: string) {
    this.selectedDiscipline = <DisciplineModel>this.disciplines.find(d => d.id == id);
  }
}
