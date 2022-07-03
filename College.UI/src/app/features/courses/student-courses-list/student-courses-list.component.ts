import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Title } from '@angular/platform-browser';
import { AdminService } from 'src/app/core/services/api/admin.service';
import { AuthenticationService } from 'src/app/core/services/auth.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { ApplyCourseDialogComponent } from '../apply-course-dialog/apply-course-dialog.component';

@Component({
  selector: 'app-student-courses-list',
  templateUrl: './student-courses-list.component.html',
  styleUrls: ['./student-courses-list.component.css']
})
export class StudentCoursesListComponent implements OnInit {
  displayedColumns: string[] = ['name', 'teacher', 'evaluation', 'absences', 'actions'];
  // dataSource = new MatTableDataSource(ELEMENT_DATA);
  dataSource!: any;
  @ViewChild(MatSort, { static: true })
  dialogRefApplyCourse!: MatDialogRef<ApplyCourseDialogComponent>
  // dialogRefAssignLeader!: MatDialogRef<AddLeaderDepartmentDialogComponent>
  sort: MatSort = new MatSort;

  constructor(private adminService: AdminService,
    private notificationService: NotificationService,
    private titleService: Title,
    private dialog: MatDialog,
    private authService: AuthenticationService
    ) { }

  ngOnInit(): void {
    this.titleService.setTitle('College - Courses');
    let user = this.authService.getCurrentUser();
    this.getStudentCourses(user.id);
  }

  getStudentCourses(id:number) {
    this.adminService.getStudentCourses(id).subscribe({
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

  applyCourse(){
    this.dialogRefApplyCourse = this.dialog.open(ApplyCourseDialogComponent,{
      minHeight: '300px',
      minWidth: '400px',
      data:{
        studentId: this.authService.getCurrentUser().id
      }
    });
    this.dialogRefApplyCourse.afterClosed().subscribe(result => {
      window.location.reload();
    });
  }

}
