import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminService } from 'src/app/core/services/api/admin.service';
import { CourseModel } from 'src/app/shared/models/courses';
import { AddCourseDialogComponent } from '../add-course-dialog/add-course-dialog.component';

@Component({
  selector: 'app-apply-course-dialog',
  templateUrl: './apply-course-dialog.component.html',
  styleUrls: ['./apply-course-dialog.component.css']
})
export class ApplyCourseDialogComponent implements OnInit {
  form!: FormGroup;
  coursesDropdown: CourseModel[] = [];
  constructor(public dialogRef: MatDialogRef<ApplyCourseDialogComponent>,
    
    @Inject(MAT_DIALOG_DATA) public data: { studentId: number },
    private adminService: AdminService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      course: new FormControl(null, Validators.required)
    })
    this.getAllCourses();
  }

  getAllCourses(){
    this.adminService.getAllCourses().subscribe({
      next: result =>{
        this.coursesDropdown = result;
      }
    })
  }
  onClose(): void {
    this.dialogRef.close();
  }

  onAdd() {
    let model = {
      studentId: this.data.studentId,
      courseId: this.form.get('course')?.value,
    }
    
    this.adminService.applyStudentCourse(model).subscribe({
      next: result => {
        this.onClose();
      },
      error: error =>{
        console.log(error.error.message);
      }
    });
    //this.dialogRef.close(this.assignBabysitterForm.value);
  }

}
