import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { AdminService } from 'src/app/core/services/api/admin.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { AddStudentDialogComponent } from '../add-student-dialog/add-student-dialog.component';

@Component({
  selector: 'app-students-list',
  templateUrl: './students-list.component.html',
  styleUrls: ['./students-list.component.css']
})
export class StudentsListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'egn', 'email', 'line', 'actions'];
  // dataSource = new MatTableDataSource(ELEMENT_DATA);
  dataSource!: any;
  @ViewChild(MatSort, { static: true })
  dialogRefNewStudent!: MatDialogRef<AddStudentDialogComponent>
  //dialogRefAddToDepartment!: MatDialogRef<AddToDepartmentDialogComponent>
  sort: MatSort = new MatSort;

  constructor(private adminService: AdminService,
    private notificationService: NotificationService,
    private titleService: Title,
    private dialog: MatDialog,) { }

  ngOnInit(): void {
    this.titleService.setTitle('College - Students');
    this.getAllStudents();
  }

  getAllStudents(){
    this.adminService.getAllStudents().subscribe({
      next: result => {
        this.dataSource = new MatTableDataSource(result);
        this.notificationService.openSnackBar('Students loaded successfully');
      },
      error: error => {
        this.notificationService.openSnackBar(error.error);
      }
    })
  }

  // addToDepartment(element:any){
  //   this.dialogRefAddToDepartment = this.dialog.open(AddToDepartmentDialogComponent,{
  //     minHeight: '200px',
  //     minWidth: '400px',
  //     data:{
  //       teacherId: element.id
  //     }
  //   });
  //   this.dialogRefAddToDepartment.afterClosed().subscribe(result => {
  //     window.location.reload();
  //   });
  // }
  addNewStudent(){
    this.dialogRefNewStudent = this.dialog.open(AddStudentDialogComponent,{
      minHeight: '300px',
      minWidth: '400px',
    });
    this.dialogRefNewStudent.afterClosed().subscribe(result => {
      window.location.reload();
    });
  }


}
