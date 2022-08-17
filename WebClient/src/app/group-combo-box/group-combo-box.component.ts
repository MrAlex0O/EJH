import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { GroupModel } from '../_models/groupModel';
import { GroupService } from '../_services/group.service.service';

@Component({
  selector: 'app-group-combo-box',
  templateUrl: './group-combo-box.component.html',
  styleUrls: ['./group-combo-box.component.css']
})
export class GroupComboBoxComponent implements OnInit {
  groups: GroupModel[] = [];
  public selectedGroup: GroupModel = { id: "", name: "" };
  @Output() myEvent = new EventEmitter<GroupModel>();
  constructor(public _groupService: GroupService) { }

  ngOnInit(): void {
    this._groupService.getAllDisciplines().subscribe(groups => this.groups = groups);

  }

  exportValue() {
    this.myEvent.emit(this.selectedGroup);
  }

}
