import { Component } from '@angular/core';
import { RequestService} from '../../shared/request.service';
import { Student } from './Student';
import { ActivatedRoute, Router} from '@angular/router';

@Component({
    moduleId: module.id,
    templateUrl: 'studentDetails.component.html'
})
export class StudentDetailsComponent {
    public student: Student;
    private id : number;

    constructor(private router: Router, private activateRoute: ActivatedRoute, requestService: RequestService) {
        this.id = activateRoute.snapshot.params['id'];
        requestService.get('students/' + this.id).subscribe((result: any) => {
            this.student = result.json();
        });
    }
}






