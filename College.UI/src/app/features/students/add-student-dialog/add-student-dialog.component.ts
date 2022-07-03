import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { AdminService } from 'src/app/core/services/api/admin.service';
import { NotificationService } from 'src/app/core/services/notification.service';
import { CreateStudentModel } from 'src/app/shared/models/students';

@Component({
  selector: 'app-add-student-dialog',
  templateUrl: './add-student-dialog.component.html',
  styleUrls: ['./add-student-dialog.component.css']
})
export class AddStudentDialogComponent implements OnInit {
  form!: FormGroup;
  loading!: boolean;
  constructor(private router: Router,
    private notificationService: NotificationService,
    private adminService: AdminService,
    public dialogRef: MatDialogRef<AddStudentDialogComponent>) {
  }
  ngOnInit(): void {
    this.createForm();
  }

  private createForm() {
    this.form = new FormGroup({
      name: new FormControl('', Validators.required),
      egn: new FormControl('', [Validators.required]),
      email: new FormControl('', [Validators.required, Validators.email]),
      line: new FormControl('', [Validators.required]), 
      username: new FormControl('', [Validators.required]),
      password: new FormControl('', [Validators.required]),
    });
  }

  onClose(){
    this.dialogRef.close();
  }

  onCreate(){
    let teacher = <CreateStudentModel>{
      name: this.form.get('name')?.value,
      egn: this.form.get('egn')?.value,
      email: this.form.get('email')?.value,
      line: this.form.get('line')?.value,
      username: this.form.get('username')?.value,
      password: this.form.get('password')?.value,
    }
    this.adminService.addNewStudent(teacher).subscribe({
      next: result => {
        this.notificationService.openSnackBar("Succesfully added new student!")
        this.onClose();
      },
      error: error => {
        this.notificationService.openSnackBar(error.error);
      }
    });
  }

}
