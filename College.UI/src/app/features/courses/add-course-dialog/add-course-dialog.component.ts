import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminService } from 'src/app/core/services/api/admin.service';
import { CreateCourseModel } from 'src/app/shared/models/courses';
import { TeacherModel } from 'src/app/shared/models/teachers';

@Component({
  selector: 'app-add-course-dialog',
  templateUrl: './add-course-dialog.component.html',
  styleUrls: ['./add-course-dialog.component.css']
})
export class AddCourseDialogComponent implements OnInit {
  form!: FormGroup;
  teachersDropdown: TeacherModel[] = [];
  constructor(public dialogRef: MatDialogRef<AddCourseDialogComponent>,
    
    @Inject(MAT_DIALOG_DATA) public data: { departmentId: number },
    private adminService: AdminService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      name: new FormControl(null, Validators.required),
      teacher: new FormControl(null, Validators.required)
    })
    this.getAllTeachers();
  }

  getAllTeachers(){
    this.adminService.getAllTeachers().subscribe({
      next: result =>{
        this.teachersDropdown = result;
      }
    })
  }
  onClose(): void {
    this.dialogRef.close();
  }

  onAdd() {
    let model = <CreateCourseModel>{
      name: this.form.get('name')?.value,
      teacherId: this.form.get('teacher')?.value
    }
    this.adminService.addNewCourse(model).subscribe({
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
