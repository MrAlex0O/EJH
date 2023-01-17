import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { GroupModel } from '../_models/groupModel';
import { GroupService } from '../_services/group.service';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-group-combo-box',
  templateUrl: './group-combo-box.component.html',
  styleUrls: ['./group-combo-box.component.css']
})
export class GroupComboBoxComponent implements OnInit, OnChanges {
  public groups: GroupModel[] = [];
  public selectedGroup: GroupModel;
  @Output() myEvent = new EventEmitter<GroupModel>();
  @Input() loading: boolean = false;
  public groupControl = new FormControl<GroupModel>(this.groups[0], Validators.required);

  constructor(private _groupService: GroupService) { }

  ngOnInit(): void { }

  ngOnChanges() {
    if (this.loading == false) {
      this.upload();
    }
  }

  public upload(): void {
    this.groups.length = 0;
    this._groupService.getAll().subscribe(groups => this.groups.push(...groups));
  }

  exportValue() {
    this.myEvent.emit(<GroupModel>this.groupControl.value);
  }

  public showById(id: string) {
    this.selectedGroup = <GroupModel>this.groups.find(g => g.id == id);
  }
}
