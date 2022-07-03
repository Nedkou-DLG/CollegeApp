import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { AdminService } from 'src/app/core/services/api/admin.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { AddDialogDepartmentComponent } from '../add-dialog-department/add-dialog-department.component';
import { AddLeaderDepartmentDialogComponent } from '../add-leader-department-dialog/add-leader-department-dialog.component';

@Component({
  selector: 'app-departments-list',
  templateUrl: './departments-list.component.html',
  styleUrls: ['./departments-list.component.css']
})
export class DepartmentsListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'faculty', 'leader', 'actions'];
  // dataSource = new MatTableDataSource(ELEMENT_DATA);
  dataSource!: any;
  @ViewChild(MatSort, { static: true })
  dialogRefNewDepartment!: MatDialogRef<AddDialogDepartmentComponent>
  dialogRefAssignLeader!: MatDialogRef<AddLeaderDepartmentDialogComponent>
  sort: MatSort = new MatSort;

  constructor(private adminService: AdminService,
    private notificationService: NotificationService,
    private titleService: Title,
    private dialog: MatDialog,) { }

  ngOnInit(): void {
    this.titleService.setTitle('College - Departments');
    this.getAllDepartments();
  }

  getAllDepartments(){
    this.adminService.getAllDepartments().subscribe({
      next: result => {
        this.dataSource = new MatTableDataSource(result);
        this.notificationService.openSnackBar('Departments loaded successfully');
      },
      error: error => {
        this.notificationService.openSnackBar(error.error);
      }
    })
  }

  addNewDepartment(){
    this.dialogRefNewDepartment = this.dialog.open(AddDialogDepartmentComponent,{
      minHeight: '300px',
      minWidth: '400px',
    });
    this.dialogRefNewDepartment.afterClosed().subscribe(result => {
      window.location.reload();
    });
  }

  addLeader(element:any){
    this.dialogRefAssignLeader = this.dialog.open(AddLeaderDepartmentDialogComponent,{
      minHeight: '200px',
      minWidth: '400px',
      data:{
        departmentId: element.id
      }
    });
    this.dialogRefAssignLeader.afterClosed().subscribe(result => {
      window.location.reload();
    });
  }
}
