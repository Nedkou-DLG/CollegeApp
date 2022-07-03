import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CoursesRoutingModule } from './courses-routing.module';
import { SharedModule } from 'src/app/shared/shared.module';
import { AddCourseDialogComponent } from './add-course-dialog/add-course-dialog.component';
import { CourseListComponent } from './course-list/course-list.component';
import { StudentCoursesListComponent } from './student-courses-list/student-courses-list.component';
import { ApplyCourseDialogComponent } from './apply-course-dialog/apply-course-dialog.component';


@NgModule({
  declarations: [
    AddCourseDialogComponent,
    CourseListComponent,
    StudentCoursesListComponent,
    ApplyCourseDialogComponent
  ],
  imports: [
    CommonModule,
    SharedModule,
    CoursesRoutingModule
  ]
})
export class CoursesModule { }
