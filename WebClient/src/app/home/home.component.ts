import { Component, OnInit } from '@angular/core';
import { BaseModel } from '../_models/BaseModel';
import { StudentModel } from '../_models/studentModel';
import { StudentService } from '../_services/student.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  models: BaseModel[] = [];
  renderFunction = (item: BaseModel) => { return `${item.surname} ${item.name} ${item.id}`; }
  constructor(private s: StudentService) { }

  ngOnInit(): void {
    this.models.length = 0;
    this.s.getAll().subscribe(m => this.models.push(...m));

  }

}
