import { ChangeDetectionStrategy, Component, EventEmitter, Input, OnChanges, OnInit, Output } from '@angular/core';
import { Router } from '@angular/router';
import { Observable } from 'rxjs';
import { GroupModel } from '../_models/groupModel';
import { GroupService } from '../_services/group.service';

@Component({
  changeDetection: ChangeDetectionStrategy.OnPush,
  selector: 'app-group-combo-box',
  templateUrl: './group-combo-box.component.html',
  styleUrls: ['./group-combo-box.component.css']
})
export class GroupComboBoxComponent implements OnInit, OnChanges {
  groups: GroupModel[] = [];
  public selectedGroup: GroupModel;
  @Output() myEvent = new EventEmitter<GroupModel>();
  @Input() loading: boolean = false;
    
  constructor(public _groupService: GroupService) { }

  ngOnInit(): void {
    this._groupService.getAll().subscribe(groups => this.groups = groups);

  }

  public showById(id: string) {
    this.selectedGroup = <GroupModel>this.groups.find(g => g.id == id);
  }
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
    this.myEvent.emit(this.selectedGroup);
  }
}
