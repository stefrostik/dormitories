import {Injectable}     from '@angular/core';
import {Http, Response, Headers, RequestOptions} from '@angular/http';
import {Registration} from '../components/register/Registration'

@Injectable()
export class AuthenticationService {
    private myHttp: Http;
    private registerUrl = 'api/account/register';
    private loginUrl = 'token';

    constructor(private http: Http) {
        this.myHttp = http;
    }

    login(loginModel: any) {
        var inputBody = 'grant_type=password&username=' + loginModel.UserName + '&password=' + loginModel.Password;
        let headers = new Headers({ 'Content-Type': 'application/x-www-form-urlencoded' });
        let options = new RequestOptions({ headers: headers });

        var respData = {};
        this.myHttp.post(this.loginUrl, inputBody, options).subscribe((result: any) => {
            var  respData: any = result.json();
            var token = respData.access_token;
            localStorage.setItem('token', token);
            return true;
        }, (errors: any) => {
            var error = errors;
            console.log(error);
            return false;
        });
    }

    register(registerModel: Registration) {
        var respData = {};
        this.myHttp.post(this.registerUrl, registerModel).subscribe((result: any) => {
            respData = result.json();
            return true;
        }, (errors: any) => {
            var error = errors;
            console.log(error);
            return false;
        });
    }
}
