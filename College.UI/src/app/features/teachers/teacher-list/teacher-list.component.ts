import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { AdminService } from 'src/app/core/services/api/admin.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { AddTeacherDialogComponent } from '../add-teacher-dialog/add-teacher-dialog.component';
import { AddToDepartmentDialogComponent } from '../add-to-department-dialog/add-to-department-dialog.component';

@Component({
  selector: 'app-teacher-list',
  templateUrl: './teacher-list.component.html',
  styleUrls: ['./teacher-list.component.css']
})
export class TeacherListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'egn', 'email', 'actions'];
  // dataSource = new MatTableDataSource(ELEMENT_DATA);
  dataSource!: any;
  @ViewChild(MatSort, { static: true })
  dialogRefNewTeacher!: MatDialogRef<AddTeacherDialogComponent>
  dialogRefAddToDepartment!: MatDialogRef<AddToDepartmentDialogComponent>
  sort: MatSort = new MatSort;

  constructor(private adminService: AdminService,
    private notificationService: NotificationService,
    private titleService: Title,
    private dialog: MatDialog,) { }

  ngOnInit(): void {
    this.titleService.setTitle('College - Teachers');
    this.getAllDepartments();
  }

  getAllDepartments(){
    this.adminService.getAllTeachers().subscribe({
      next: result => {
        this.dataSource = new MatTableDataSource(result);
        this.notificationService.openSnackBar('Teachers loaded successfully');
      },
      error: error => {
        this.notificationService.openSnackBar(error.error);
      }
    })
  }

  addToDepartment(element:any){
    this.dialogRefAddToDepartment = this.dialog.open(AddToDepartmentDialogComponent,{
      minHeight: '200px',
      minWidth: '400px',
      data:{
        teacherId: element.id
      }
    });
    this.dialogRefAddToDepartment.afterClosed().subscribe(result => {
      window.location.reload();
    });
  }
  addNewTeacher(){
    this.dialogRefNewTeacher = this.dialog.open(AddTeacherDialogComponent,{
      minHeight: '300px',
      minWidth: '400px',
    });
    this.dialogRefNewTeacher.afterClosed().subscribe(result => {
      window.location.reload();
    });
  }

  

}
