﻿import { Component} from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { AuthenticationService } from '../../shared/authentication.service';
import { Login} from './Login';

@Component({
    moduleId: module.id,
    templateUrl: 'login.component.html'
})

export class LoginComponent {
    model: Login = new Login();
    loading = false;
    private returnUrl: string;

    constructor(
        private route: ActivatedRoute,
        private router: Router,
        private authService: AuthenticationService) {
    }

    login() {
        this.loading = true;
        this.authService.login(this.model).subscribe((response: any) => {
            this.loading = false;
            if (this.authService.currentUserRole == 'Admin') {
                this.router.navigate(['admin-home']);
            } else
                if (this.authService.currentUserRole == 'Student')
                {
                    this.router.navigate(['student-home']);
                } else
                    if (this.authService.currentUserRole == 'DormitoryAdmin') {
                        this.router.navigate(['dormitory-admin-home']);
                    } else
                        if (this.authService.currentUserRole == 'FacultyAdmin') {
                            this.router.navigate(['faculty-admin-home']);
                        }
        }, (error: any) => {
            let temp = error;
            console.log(temp);
            this.loading = false;
        });
    }
}
