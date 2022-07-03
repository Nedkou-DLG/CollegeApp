import { UserType } from "./user-types-enum";

export interface LoginUser{
    username: string,
    password: string
}
export interface AuthUser{
    token: string,
    email: string,
    id: number,
    alias: string,
    expiration: Date,
    name: string,
    username: string,
    type: UserType,
}