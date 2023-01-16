import { NgModule } from '@angular/core';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSelectModule } from '@angular/material/select';

@NgModule({
  imports: [MatButtonModule, MatFormFieldModule, MatSelectModule],
  exports: [MatButtonModule, MatFormFieldModule, MatSelectModule]
})
export class MaterialAppModule { }
