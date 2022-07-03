import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/core/services/api/admin.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { CreateTeacherModel } from 'src/app/shared/models/teachers';

@Component({
  selector: 'app-add-teacher-dialog',
  templateUrl: './add-teacher-dialog.component.html',
  styleUrls: ['./add-teacher-dialog.component.css']
})
export class AddTeacherDialogComponent implements OnInit {
  form!: FormGroup;
  loading!: boolean;
  constructor(private router: Router,
    private notificationService: NotificationService,
    private adminService: AdminService,
    public dialogRef: MatDialogRef<AddTeacherDialogComponent>) {
  }
  ngOnInit(): void {
    this.createForm();
  }

  private createForm() {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      egn: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
    });
  }

  onClose(){
    this.dialogRef.close();
  }

  onCreate(){
    let teacher = <CreateTeacherModel>{
      name: this.form.get('name')?.value,
      egn: this.form.get('egn')?.value,
      email: this.form.get('email')?.value,
      username: this.form.get('username')?.value,
      password: this.form.get('password')?.value,
    }
    this.adminService.addNewTeacher(teacher).subscribe({
      next: result => {
        this.notificationService.openSnackBar("Succesfully added new teacher!")
        this.onClose();
      },
      error: error => {
        this.notificationService.openSnackBar(error.error);
      }
    });
  }

}
