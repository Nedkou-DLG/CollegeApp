import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { StudentsRoutingModule } from './students-routing.module';
import { StudentsListComponent } from './students-list/students-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { AddStudentDialogComponent } from './add-student-dialog/add-student-dialog.component';


@NgModule({
  declarations: [
    StudentsListComponent,
    AddStudentDialogComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    StudentsRoutingModule
  ]
})
export class StudentsModule { }
