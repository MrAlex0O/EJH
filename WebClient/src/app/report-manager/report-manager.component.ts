import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';

@Component({
  selector: 'report-manager',
  templateUrl: './report-manager.component.html',
  styleUrls: ['./report-manager.component.scss']
})
export class ReportManagerComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  columnHeader = { 'profileName': 'Profile Name', 'profileDesc': 'Description', 'adminUser': 'Admin User', 'id': '' };

  tableData: ProfileSetUp[] = [
    {
      id: 1,
      profileName: "Cameron Villams",
      profileDesc: "Face to face contact",
      adminUser: "Iwan Rynders",
      action: ""
    },
    {
      id: 2,
      profileName: "Charl Angle",
      profileDesc: "Face to face contact",
      adminUser: "Unknown",
      action: ""
    },
    {
      id: 3,
      profileName: "Johan Abraham",
      profileDesc: "Face to face contact",
      adminUser: "Unknown",
      action: ""
    },
    {
      id: 4,
      profileName: "Niekie Gadgilly",
      profileDesc: "Face to face contact",
      adminUser: "Unknown",
      action: ""
    },
    {
      id: 5,
      profileName: "Veer S",
      profileDesc: "Face to face contact",
      adminUser: "Unknown",
      action: ""
    }
  ];
}


export interface ProfileSetUp {
  id: number;
  profileName: string;
  profileDesc: string;
  adminUser: string;
  action: string;
}
