import {Injectable}     from '@angular/core';
import {Http, Response, Headers, RequestOptions} from '@angular/http';
import {Registration} from '../components/register/Registration'
import { Observable } from 'rxjs/Observable';

@Injectable()
export class AuthenticationService {
    private registerUrl = 'api/account/register';
    private loginUrl = 'token';
    public currentUserRole: string = 'No Role';
    public currentUserName: string = 'No UserName';
    public currentUserId: number = 0;

    constructor(private http: Http) {
        this.currentUserId = Number(localStorage.getItem('userId'));
        this.currentUserName = localStorage.getItem('userName');
        this.currentUserRole = localStorage.getItem('userRole');
    }

    login(loginModel: any) {
        var inputBody = 'grant_type=password&username=' + loginModel.UserName + '&password=' + loginModel.Password;
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });

        return this.http.post(this.loginUrl, inputBody, options)
            .map((response: any) => {
                let body = response.json();
                this.currentUserRole = JSON.parse(body.roles)[0];
                this.currentUserId = Number(body.id);
                this.currentUserName = body.userName;

                localStorage.setItem('token', body.access_token);
                localStorage.setItem('userName', this.currentUserName);
                localStorage.setItem('userRole', this.currentUserRole);
                localStorage.setItem('userId', String(this.currentUserId));
                return body;
            }).catch((error: any) => {
                return Observable.throw(error || 'Login error');
            });
    }

    register(registerModel: Registration) {
        return this.http.post(this.registerUrl, registerModel)
            .map((result: Response) => result)
            .catch((error: any) => {
                return Observable.throw(error || 'Register error');
            });
    }

    signOut() {
        this.currentUserId = 0;
        this.currentUserName = 'No name';
        this.currentUserRole = 'No role';

        localStorage.removeItem('token');
        localStorage.removeItem('userName');
        localStorage.removeItem('userRole');
        localStorage.removeItem('userId');
        return true;
    }
}
