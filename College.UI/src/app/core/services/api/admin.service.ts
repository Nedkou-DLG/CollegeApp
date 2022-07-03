import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { CourseModel, CreateCourseModel } from 'src/app/shared/models/courses';
import { CreateDepartmentModel, DepartmentModel } from 'src/app/shared/models/departments';
import { CreateStudentModel, StudentModel } from 'src/app/shared/models/students';
import { CreateTeacherModel, TeacherModel } from 'src/app/shared/models/teachers';
import { environment } from 'src/environments/environment';
import { AuthenticationService } from '../auth.service';

@Injectable({
  providedIn: 'root'
})
export class AdminService {

  constructor(private http: HttpClient,
    private authService: AuthenticationService) { }

    getAllDepartments(){
      return this.http.get<DepartmentModel[]>(`${environment.apiUrl}/department/all`)
    }

    addNewDepartment(model: CreateDepartmentModel){
      return this.http.post(`${environment.apiUrl}/department/add`, model)
    }

    getTeachersByDepartment(id: number){
      return this.http.get<TeacherModel[]>(`${environment.apiUrl}/department/teachers/${id}`)
    }

    assignLeaderToDepartment(model: any){
      return this.http.post(`${environment.apiUrl}/department/leader/`, model)
    }

    getAllTeachers(){
      return this.http.get<TeacherModel[]>(`${environment.apiUrl}/teacher/all`)
    }

    addNewTeacher(model: CreateTeacherModel){
      return this.http.post(`${environment.apiUrl}/teacher/add`, model);
    }

    assignTeacherToDepartment(model: any){
      return this.http.post(`${environment.apiUrl}/teacher/assign-department`, model)
    }

    getAllStudents(){
      return this.http.get<StudentModel[]>(`${environment.apiUrl}/student/all`)
    }

    addNewStudent(model: CreateStudentModel){
      return this.http.post(`${environment.apiUrl}/student/add`, model);
    }

    getAllCourses(){
      return this.http.get<CourseModel[]>(`${environment.apiUrl}/course/all`)
    }

    addNewCourse(model: CreateCourseModel){
      return this.http.post(`${environment.apiUrl}/course/add`, model);
    }
}
