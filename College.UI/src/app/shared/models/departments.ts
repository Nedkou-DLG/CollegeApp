import { TeacherModel } from "./teachers";

export interface DepartmentModel{
    id: number,
    name: string,
    faculty: string,
    leader: TeacherModel
}

export interface CreateDepartmentModel{
    name:string,
    faculty: string
}