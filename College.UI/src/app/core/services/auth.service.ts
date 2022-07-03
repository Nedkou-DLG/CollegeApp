import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { delay, map } from 'rxjs/operators';
import jwt_decode from 'jwt-decode';
import * as moment from 'moment';

import { environment } from '../../../environments/environment';
import { of, EMPTY } from 'rxjs';
import { AuthUser, LoginUser } from 'src/app/shared/models/auth';

@Injectable({
    providedIn: 'root'
})
export class AuthenticationService {

    constructor(private http: HttpClient,
        @Inject('LOCALSTORAGE') private localStorage: Storage) {
    }

    login(loginUser: LoginUser) {
        return this.http.post<AuthUser>(`${environment.apiUrl}/auth/authenticate`, loginUser)
            .pipe(map(user => {
                // store user details and jwt token in local storage to keep user logged in between page refreshes
                
                const decoded = jwt_decode(user.token);
                user.expiration = new Date((decoded as {exp:number}).exp * 1000);
                user.alias = user.email.split('@')[0]
                localStorage.setItem('currentUser', JSON.stringify(user));

                return true;
            }));
    }

    logout(): void {
        // clear token remove user from local storage to log user out
        this.localStorage.removeItem('currentUser');
    }

    getCurrentUser(): AuthUser {
        // TODO: Enable after implementation
         return JSON.parse(this.localStorage.getItem('currentUser') || '{}');
        
    }

    passwordResetRequest(email: string) {
        return of(true).pipe(delay(1000));
    }

    changePassword(email: string, currentPwd: string, newPwd: string) {
        return of(true).pipe(delay(1000));
    }

    passwordReset(email: string, token: string, password: string, confirmPassword: string): any {
        return of(true).pipe(delay(1000));
    }
}
