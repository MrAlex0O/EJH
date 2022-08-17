import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { GroupComboBoxComponent } from '../group-combo-box/group-combo-box.component';
import { GroupModel } from '../_models/groupModel';

@Component({
  selector: 'app-group-manager',
  templateUrl: './group-manager.component.html',
  styleUrls: ['./group-manager.component.css']
})
export class GroupManagerComponent implements OnInit {

  constructor() { }
  @Input() selected: GroupModel = {id:"",name:"" };
  @ViewChild(GroupComboBoxComponent)
    viewChild!: GroupComboBoxComponent;


  ngOnInit(): void {
  }
  importValue(group: GroupModel) {
    this.selected = this.viewChild.selectedGroup;
    console.log(group);
  }
  update() {
    this.selected = this.viewChild.selectedGroup;
    console.log(this.selected);
    return this.selected;
  }
  add() { console.log("add") }

}
