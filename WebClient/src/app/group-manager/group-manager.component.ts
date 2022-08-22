import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { GroupComboBoxComponent } from '../group-combo-box/group-combo-box.component';
import { GroupModel } from '../_models/groupModel';
import { GroupService } from '../_services/group.service'

@Component({
  selector: 'app-group-manager',
  templateUrl: './group-manager.component.html',
  styleUrls: ['./group-manager.component.css']
})
export class GroupManagerComponent implements OnInit {

  constructor(private _groupService: GroupService, private _router:Router) { }
  @Input() selected: GroupModel = { id: "", name: "" };
  name: string = "";
  @ViewChild(GroupComboBoxComponent)
    viewChild!: GroupComboBoxComponent;
  loading: boolean = false;

  ngOnInit(): void {
    this.name = this.selected.name;
  }
  importValue(group: GroupModel) {
    this.selected = this.viewChild.selectedGroup;
    this.name = this.viewChild.selectedGroup.name;
    console.log(group);
  }
  update() {
    this.loading = true;
    this._groupService.Update(this.selected).subscribe(() => this.loading = false);
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
