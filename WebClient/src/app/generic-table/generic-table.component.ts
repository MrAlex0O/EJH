import { Component, OnInit, Input, ViewChild } from '@angular/core';
import { MatTableDataSource } from '@angular/material/table';
import { MatSort, Sort } from '@angular/material/sort'
@Component({
  selector: 'app-generic-table',
  templateUrl: './generic-table.component.html',
  styleUrls: ['./generic-table.component.scss']
})
export class GenericTableComponent implements OnInit {

  @Input() tableData: unknown[] | undefined;
  @Input() columnHeader: any;
  @Input() source: any;
  objectKeys = Object.keys;
  dataSource: MatTableDataSource<unknown>;

  @ViewChild(MatSort, { static: true }) sort: MatSort;

  constructor() { }

  ngOnInit() {
    console.log(this.tableData);
    this.dataSource = new MatTableDataSource(this.tableData);
    this.dataSource.sort = this.sort;
  }


  sortData(sort: Sort) {
      const data = (<GenericReportResponse[]>this.tableData).slice();
      if (!sort.active || sort.direction === '') {
        this.tableData = data;
        return;
      }

      this.tableData = data.sort((a: GenericReportResponse, b: GenericReportResponse) => {
        const isAsc = sort.direction === 'asc';
        switch (sort.active) {
          case 'groupName': return compare(a.groupName, b.groupName, isAsc);
          case 'fullName': return compare(a.fullName, b.fullName, isAsc);
          case 'id': return compare(a.id, b.id, isAsc);
          default: return 0;
        }
      });
  }

}

function compare(a: number | string, b: number | string, isAsc: boolean) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}
export interface GenericReportResponse {
  groupName: string;
  fullName: string;
  id: string;
}
