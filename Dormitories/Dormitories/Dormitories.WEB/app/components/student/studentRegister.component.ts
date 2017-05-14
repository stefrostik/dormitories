import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../shared/authentication.service';
import { StudentRegistration } from './StudentRegistration';
@Component({
    moduleId: module.id,
    templateUrl: 'studentRegister.component.html'
})

export class StudentRegisterComponent {
    model: StudentRegistration = new StudentRegistration();
    loading = false;

    constructor(private router: Router, private authService: AuthenticationService) {
    }

    register() {
        this.loading = true;
        this.authService.register(this.model).subscribe((response: any) => {
            let temp = response;
            this.loading = false;
            this.router.navigate(['../students']);

        }, (error: any) => {
            let temp = error;
            console.log(error);
            alert('Registration error!');
        });
    }
}

