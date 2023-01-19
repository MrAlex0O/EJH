import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { BaseModel } from '../_models/BaseModel';
import { StudentService } from '../_services/student.service';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-combo-box',
  templateUrl: './me-combo-box.component.html',
  styleUrls: ['./me-combo-box.component.css']
})
export class GenericComboBoxComponent implements OnInit, OnChanges {
  @Input() public models: BaseModel[] = [];
  public selectedModel: BaseModel;
  @Output() myEvent = new EventEmitter<BaseModel>();
  @Input() loading: boolean = false;
  @Input() viewPattern = (item: any) => {
    return item.toString();
  };

  public modelControl = new FormControl<BaseModel>(this.models[0], Validators.required);

  constructor() { }

  ngOnInit(): void { }

  ngOnChanges() {
    console.log(this.models);
    
    if (this.loading == false) {
    }
  }

  exportValue() {
    this.myEvent.emit(<BaseModel>this.modelControl.value);
  }

  public showById(id: string) {
    this.selectedModel = <BaseModel>this.models.find(g => g.id == id);
  }
}

