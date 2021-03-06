import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { AdminService } from 'src/app/core/services/api/admin.service';
import { AuthenticationService } from 'src/app/core/services/auth.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { UserType } from 'src/app/shared/models/user-types-enum';
import { AddCourseDialogComponent } from '../add-course-dialog/add-course-dialog.component';

@Component({
  selector: 'app-course-list',
  templateUrl: './course-list.component.html',
  styleUrls: ['./course-list.component.css']
})
export class CourseListComponent implements OnInit {

  displayedColumns: string[] = ['name', 'teacher', 'actions'];
  // dataSource = new MatTableDataSource(ELEMENT_DATA);
  dataSource!: any;
  @ViewChild(MatSort, { static: true })
  dialogRefNewCourse!: MatDialogRef<AddCourseDialogComponent>
  // dialogRefAssignLeader!: MatDialogRef<AddLeaderDepartmentDialogComponent>
  sort: MatSort = new MatSort;

  constructor(private adminService: AdminService,
    private notificationService: NotificationService,
    private titleService: Title,
    private dialog: MatDialog,
    private authService: AuthenticationService) { }

  ngOnInit(): void {
    this.titleService.setTitle('College - Courses');
    var user = this.authService.getCurrentUser();
    if(user.type === UserType.Admin){
      this.getAllCourses();
    }else if(user.type === UserType.Teacher){
      this.getTeacherCourses(user.id);
    }
  }

  getTeacherCourses(id: number) {
    this.adminService.getTeacherCourses(id).subscribe({
      next: result => {
        this.dataSource = new MatTableDataSource(result);
        this.notificationService.openSnackBar('Courses loaded successfully');
      },
      error: error => {
        this.notificationService.openSnackBar(error.error);
      }
    });
  }

  getAllCourses(){
    this.adminService.getAllCourses().subscribe({
      next: result => {
        this.dataSource = new MatTableDataSource(result);
        this.notificationService.openSnackBar('Courses loaded successfully');
      },
      error: error => {
        this.notificationService.openSnackBar(error.error);
      }
    })
  }

  addNewCourse(){
    this.dialogRefNewCourse = this.dialog.open(AddCourseDialogComponent,{
      minHeight: '300px',
      minWidth: '400px',
    });
    this.dialogRefNewCourse.afterClosed().subscribe(result => {
      window.location.reload();
    });
  }

  // addLeader(element:any){
  //   this.dialogRefAssignLeader = this.dialog.open(AddLeaderDepartmentDialogComponent,{
  //     minHeight: '200px',
  //     minWidth: '400px',
  //     data:{
  //       departmentId: element.id
  //     }
  //   });
  //   this.dialogRefAssignLeader.afterClosed().subscribe(result => {
  //     window.location.reload();
  //   });
  // }
}
