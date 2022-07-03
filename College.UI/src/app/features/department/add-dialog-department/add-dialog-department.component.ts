import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/core/services/api/admin.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { CreateDepartmentModel } from 'src/app/shared/models/departments';

@Component({
  selector: 'app-add-dialog-department',
  templateUrl: './add-dialog-department.component.html',
  styleUrls: ['./add-dialog-department.component.css']
})
export class AddDialogDepartmentComponent implements OnInit {

  form!: FormGroup;
  loading!: boolean;
  constructor(private router: Router,
    private notificationService: NotificationService,
    private adminService: AdminService,
    public dialogRef: MatDialogRef<AddDialogDepartmentComponent>) {
  }
  ngOnInit(): void {
    this.createForm();
  }

  private createForm() {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      faculty: new FormControl('', [Validators.required]),
      
    });
  }

  onClose(){
    this.dialogRef.close();
  }

  onCreate(){
    let department = <CreateDepartmentModel>{
      name: this.form.get('name')?.value,
      faculty: this.form.get('faculty')?.value

    }
    this.adminService.addNewDepartment(department).subscribe({
      next: result => {
        this.notificationService.openSnackBar("Succesfully added new department!")
        this.onClose();
      },
      error: error => {
        this.notificationService.openSnackBar(error.error);
      }
    });
  }

}
