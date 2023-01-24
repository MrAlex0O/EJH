import { Component, Input, OnInit, TemplateRef, ViewChild, ViewContainerRef } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { GenericComboBoxComponent } from '../generic-combo-box/generic-combo-box.component';
import { GenericReportResponse, GenericTableComponent } from '../generic-table/generic-table.component';
import { DisciplineModel } from '../_models/disciplineModel';
import { GroupModel } from '../_models/groupModel';
import { DisciplineVisitsModel } from '../_models/Reports/DisciplineVisitsModel';
import { ReportModel } from '../_models/Reports/reportModel';
import { DisciplineService } from '../_services/discipline.service';
import { GroupService } from '../_services/group.service';
import { ReportService } from '../_services/report.service';

@Component({
  selector: 'report-manager',
  templateUrl: './report-manager.component.html',
  styleUrls: ['./report-manager.component.scss']
})
export class ReportManagerComponent implements OnInit {

  @Input() selectedReport: ReportModel;
  @Input() selectedDiscipline: DisciplineModel;
  @Input() selectedGroup: GroupModel;
  reports: ReportModel[] = [{ id: reportType.disciplineVisits, name: "Посещаемость дисциплин (за все время)" }];
  disciplines: DisciplineModel[] = [];
  groups: GroupModel[] = [];
  @ViewChild(GenericComboBoxComponent) viewChild!: GenericComboBoxComponent;
  @ViewChild(GenericTableComponent) tableViewChild!: GenericTableComponent;
  reportRenderFunction = (item: ReportModel) => { return `${item.name}`; }
  disciplineRenderFunction = (item: DisciplineModel) => { return `${item.name} ${item.groupName}`; }
  groupRenderFunction = (item: GroupModel) => { return `${item.name}`; }
  loading: boolean = false;

  tableData: DisciplineVisitsModel[] = [];

  constructor(private _reportService: ReportService, private _disciplineService: DisciplineService,
              private _groupService: GroupService  ) { }

  ngOnInit() {
    this._disciplineService.getAll().subscribe(disciplines => this.disciplines.push(...disciplines));
    this._groupService.getAll().subscribe(groups => this.groups.push(...groups));
  }

  columnHeader = { 'id': 'Id', 'fullName': 'Full name', 'groupName': 'Group name'};
  columnHeader1 = {
    'fullName': 'ФИО', 'present': 'Присутствовал', 'missing': 'Отсутствовал', 'liberation': 'Освобождение'
    , 'anotherSubgroup': 'Другая подгруппа', 'seriousReason':'Уважительная причина', 'incalculable':'Невычислимо'
  };

  importReport(report: ReportModel) {
    this.selectedReport = report;
  }
  importGroup(group: GroupModel) {
    this.selectedGroup = group;
  }
  importDiscipline(discipline: DisciplineModel) {
    this.selectedDiscipline = discipline;

  }

  getReportData() {
    this.tableData.length = 0;
    switch (this.selectedReport.id) {
      case reportType.disciplineVisits: {

        this._reportService.getAll(this.selectedDiscipline.id).subscribe(data => {
          this.tableData.push(...data);
          this.rerender();
        });
        break;
      }
    }
    
  }

  @ViewChild('outlet', { read: ViewContainerRef }) outletRef: ViewContainerRef;
  @ViewChild('content', { read: TemplateRef }) contentRef: TemplateRef<any>;

  rerender() {
    this.outletRef.clear();
    this.outletRef.createEmbeddedView(this.contentRef);
  }


}


enum reportType {
  disciplineVisits = "disciplineVisits"
}
