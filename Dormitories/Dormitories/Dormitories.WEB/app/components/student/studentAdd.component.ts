import { Component } from '@angular/core';
import { RequestService} from '../../shared/request.service';
import { Student } from './Student';
import { ActivatedRoute, Router} from '@angular/router';

@Component({
    moduleId: module.id,
    templateUrl: 'studentAdd.component.html'
})
export class StudentAddComponent {
    public students: Student[];
    public roomId: number;
    private requestService : RequestService;
    myRouter: Router;

    constructor(private router: Router, private activateRoute: ActivatedRoute, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs;
        this.roomId = activateRoute.snapshot.params['roomId'];
        this.requestService.get('students').subscribe(result => {
            this.students = result.json();
        });
    }

    Add(myItem: Student) {
        myItem.RoomId = this.roomId;
        this.requestService.put('students', myItem).subscribe((resp: any) => {
            this.myRouter.navigate(['/room/details/'+myItem.RoomId]);
        });
    }
}






