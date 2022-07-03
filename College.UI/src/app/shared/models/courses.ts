import { TeacherModel } from "./teachers";

export interface CourseModel{
    id: number,
    name: string,
    teacher: TeacherModel
}

export interface CreateCourseModel{
    name: string,
    teacherId: number
}