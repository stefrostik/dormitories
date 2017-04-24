import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';
import { Student } from './Student';
import { Router } from '@angular/router';


@Component({
    moduleId: module.id,
    templateUrl: 'students.component.html'
})
export class StudentComponent {
    public students: Student[];
    requestService: RequestService;
    myRouter: Router;

    constructor(private router: Router, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs;
        this.requestService.get('students').subscribe(result => {
            this.students = result.json();
        });
    }

    Delete(id: number) {
        this.requestService.delete('students/' + id).subscribe((resp: any) => {
            this.students = this.students.filter(x => x.Id !== id);
        });
    }
}






