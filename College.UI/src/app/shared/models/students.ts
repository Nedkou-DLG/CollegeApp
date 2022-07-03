export interface StudentModel {
    id: number,
    name: string,
    egn: string,
    line: string,
    email: string
}

export interface CreateStudentModel {
    name: string,
    egn: string,
    line: string,
    email: string,
    username: string,
    password: string
}