import { Component} from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { RequestService} from '../../shared/request.service';
import { Student } from './Student';

@Component({
    moduleId: module.id,
    templateUrl: 'studentRegister.component.html'
})
export class StudentRegisterComponent {
    public student: Student;
    private requestService : RequestService;
    myRouter: Router;

    constructor(private router: Router, private activateRoute: ActivatedRoute, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs;
        this.student = new Student();
    }

    Done(myItem: Student) {
        this.requestService.post('students', myItem).subscribe((resp: any) => {
            this.student = resp.json();
            this.myRouter.navigate(['student']);
        });
    }
}