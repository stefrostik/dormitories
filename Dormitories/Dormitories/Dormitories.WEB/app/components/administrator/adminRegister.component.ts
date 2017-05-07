import { Component} from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { AuthenticationService} from '../../shared/authentication.service';
import { AdminRegistration } from './AdminRegistration';

@Component({
    moduleId: module.id,
    templateUrl: 'adminRegister.component.html'
})
export class AdminRegisterComponent {
    public model: AdminRegistration = new AdminRegistration();

    constructor(private router: Router,
        private activateRoute: ActivatedRoute,
        private authService: AuthenticationService) {
    }

    register() {
        this.authService.register(this.model).subscribe((response: any) => {
            let temp = response;
            this.router.navigate(['/admin-home/administrators']);

        }, (error: any) => {
            let temp = error;
            console.log(error);
            alert('Registration error!');
        });
    }
}