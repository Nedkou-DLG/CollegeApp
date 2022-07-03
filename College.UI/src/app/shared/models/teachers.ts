export interface TeacherModel {
    id: number,
    name: string,
    egn: string
    email: string
}

export interface CreateTeacherModel {
    name: string,
    egn: string,
    email: string,
    username: string,
    password: string,
}