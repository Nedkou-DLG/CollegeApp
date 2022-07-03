import { Component, Inject, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdminService } from 'src/app/core/services/api/admin.service';
import { DepartmentModel } from 'src/app/shared/models/departments';

@Component({
  selector: 'app-add-to-department-dialog',
  templateUrl: './add-to-department-dialog.component.html',
  styleUrls: ['./add-to-department-dialog.component.css']
})
export class AddToDepartmentDialogComponent implements OnInit {

  form!: FormGroup;
  departmentsDropdown: DepartmentModel[] = [];
  constructor(public dialogRef: MatDialogRef<AddToDepartmentDialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { teacherId: number },
    private adminService: AdminService) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      department: new FormControl(null, Validators.required)
    })
    this.getAllDepartments();
  }

  getAllDepartments(){
    this.adminService.getAllDepartments().subscribe({
      next: result =>{
        this.departmentsDropdown = result;
      }
    })
  }
  onClose(): void {
    this.dialogRef.close();
  }

  onAssign() {
    let departmentId = this.form.get('department')?.value;
    let model = {
      departmentId: departmentId,
      teacherId: this.data.teacherId
    }
    this.adminService.assignTeacherToDepartment(model).subscribe({
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
