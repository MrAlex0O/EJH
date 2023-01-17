import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { GroupComboBoxComponent } from '../group-combo-box/group-combo-box.component';
import { GroupModel } from '../_models/groupModel';
import { GroupService } from '../_services/group.service'

@Component({
  selector: 'app-group-manager',
  templateUrl: './group-manager.component.html',
  styleUrls: ['./group-manager.component.css']
})
export class GroupManagerComponent implements OnInit {

  @Input() selected: GroupModel = { id: "", name: "" };
  name: string = "";
  @ViewChild(GroupComboBoxComponent)
  viewChild!: GroupComboBoxComponent;
  loading: boolean = false;

  constructor(private _groupService: GroupService) { }

  ngOnInit(): void { }

  importValue(group: GroupModel) {
    this.selected = group;
    this.name = group.name;
    console.log(group);
  }
  update() {
    let group: GroupModel = { name: this.name, id: this.selected.id }
    this.loading = true;
    this._groupService.Update(group).subscribe(() => this.loading = false);
  }
  add() {
    let group: GroupModel = { name: this.name, id: "" }
    this.loading = true;
    this._groupService.Add(group).subscribe(() => this.loading = false);
  }
  delete() {
    this.loading = true;
    this._groupService.Delete(this.selected).subscribe(() => this.loading = false);
  }

}
