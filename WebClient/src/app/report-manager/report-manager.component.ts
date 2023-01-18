import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import { GenericReportResponse } from '../generic-table/generic-table.component';

@Component({
  selector: 'report-manager',
  templateUrl: './report-manager.component.html',
  styleUrls: ['./report-manager.component.scss']
})
export class ReportManagerComponent implements OnInit {

  constructor() { }

  ngOnInit() {
  }

  columnHeader = { 'id': 'Id', 'fullName': 'Full name', 'groupName': 'Group name'};

  tableData: GenericReportResponse[] = [
    {
      id: "1",
      fullName: "Cameron Villams",
      groupName: "a"
    },
    {
      id: "2",
      fullName: "Charl Angle",
      groupName: "b"
    },
    {
      id: "3",
      fullName: "Johan Abraham",
      groupName: "c"
    },
    {
      id: "4",
      fullName: "Niekie Gadgilly",
      groupName: "d"
    },
    {
      id: "5",
      fullName: "Veer S",
      groupName: "2"
    },
    {
      id: "6",
      fullName: "Veer Sancho",
      groupName: "1"
    }
  ];
}


