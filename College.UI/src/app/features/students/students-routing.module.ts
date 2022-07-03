import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from 'src/app/shared/layout/layout.component';
import { StudentsListComponent } from './students-list/students-list.component';

const routes: Routes = [{
  path: '',
  component: LayoutComponent,
  children: [
    { path: '', component: StudentsListComponent }
  ]
}];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class StudentsRoutingModule { }
