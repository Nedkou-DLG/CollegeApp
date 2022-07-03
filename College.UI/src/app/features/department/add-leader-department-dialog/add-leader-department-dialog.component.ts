import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminService } from 'src/app/core/services/api/admin.service';
import { TeacherModel } from 'src/app/shared/models/teachers';

@Component({
  selector: 'app-add-leader-department-dialog',
  templateUrl: './add-leader-department-dialog.component.html',
  styleUrls: ['./add-leader-department-dialog.component.css']
})
export class AddLeaderDepartmentDialogComponent implements OnInit {

  form!: FormGroup;
  leadersDropdown: TeacherModel[] = [];
  constructor(public dialogRef: MatDialogRef<AddLeaderDepartmentDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { departmentId: number },
    private adminService: AdminService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      leader: new FormControl(null, Validators.required)
    })
    this.getAllTeachers();
  }

  getAllTeachers(){
    this.adminService.getTeachersByDepartment(this.data.departmentId).subscribe({
      next: result =>{
        this.leadersDropdown = result;
      }
    })
  }
  onClose(): void {
    this.dialogRef.close();
  }

  onAssign() {
    let leaderId = this.form.get('leader')?.value;
    let model = {
      departmentId: this.data.departmentId,
      teacherId: leaderId
    }
    this.adminService.assignLeaderToDepartment(model).subscribe({
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
