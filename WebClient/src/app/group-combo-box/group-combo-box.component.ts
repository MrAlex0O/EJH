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
  public selectedGroup: GroupModel = { id: "", name: "" };
  @Output() myEvent = new EventEmitter<GroupModel>();
  @Input() loading: boolean = false;
    
  constructor(public _groupService: GroupService, private _router: Router) { }

  ngOnInit(): void {
    this._groupService.getAll().subscribe(groups => this.groups = groups);

  }
  ngOnChanges() {
    if (this.loading == false) {
      this.upload();
    }
  }
  public upload(): void {
    this.groups.length = 0;
    this._groupService.getAll().subscribe(groups => this.groups.push(...groups));
    //this._groupService.getAll().subscribe(groups => this.groups.push(...groups));
  }
  exportValue() {
    this.myEvent.emit(this.selectedGroup);
  }
}
