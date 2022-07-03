import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoursesRoutingModule } from './courses-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AddCourseDialogComponent } from './add-course-dialog/add-course-dialog.component';
import { CourseListComponent } from './course-list/course-list.component';


@NgModule({
  declarations: [
    AddCourseDialogComponent,
    CourseListComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    CoursesRoutingModule
  ]
})
export class CoursesModule { }
