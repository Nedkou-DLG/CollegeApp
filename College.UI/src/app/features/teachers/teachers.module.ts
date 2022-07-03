import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TeachersRoutingModule } from './teachers-routing.module';
import { TeacherListComponent } from './teacher-list/teacher-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { AddTeacherDialogComponent } from './add-teacher-dialog/add-teacher-dialog.component';
import { AddToDepartmentDialogComponent } from './add-to-department-dialog/add-to-department-dialog.component';


@NgModule({
  declarations: [
    TeacherListComponent,
    AddTeacherDialogComponent,
    AddToDepartmentDialogComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    TeachersRoutingModule
  ]
})
export class TeachersModule { }
