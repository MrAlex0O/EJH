import { Component, OnInit } from '@angular/core';
import { Guid } from 'guid-typescript';
import { map } from 'rxjs/operators';
import { DisciplineService } from '../_services/discipline.service';


@Component({
  selector: 'app-disciplines-combo-box',
  templateUrl: './disciplines-combo-box.component.html',
  styleUrls: ['./disciplines-combo-box.component.css']
})
export class DisciplinesComboBoxComponent implements OnInit {
  
  public disciplines: any;
   selectedValue: string = "";


  constructor(private disciplineService: DisciplineService) {
  }




  ngOnInit(): void {
    this.disciplineService.getAllDisciplines().subscribe(disciplines => this.disciplines = disciplines);
  }
}
