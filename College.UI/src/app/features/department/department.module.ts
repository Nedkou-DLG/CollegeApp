import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { DepartmentRoutingModule } from './department-routing.module';
import { DepartmentsListComponent } from './departments-list/departments-list.component';
import { SharedModule } from 'src/app/shared/shared.module';
import { AddDialogDepartmentComponent } from './add-dialog-department/add-dialog-department.component';
import { AddLeaderDepartmentDialogComponent } from './add-leader-department-dialog/add-leader-department-dialog.component';


@NgModule({
  declarations: [
    DepartmentsListComponent,
    AddDialogDepartmentComponent,
    AddLeaderDepartmentDialogComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    DepartmentRoutingModule
  ]
})
export class DepartmentModule { }
