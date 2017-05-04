import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from '../../shared/authentication.service';
import { Login} from './Login';

@Component({
    moduleId: module.id,
    templateUrl: 'login.component.html'
})

export class LoginComponent {
    model: Login =  new Login();
    loading = false;
    private returnUrl: string;
    private authenticationService: AuthenticationService;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private as: AuthenticationService) {

        this.authenticationService = as;
    }

    login() {
        //this.loading = true;
        var res = this.authenticationService.login(this.model);
    }
}
