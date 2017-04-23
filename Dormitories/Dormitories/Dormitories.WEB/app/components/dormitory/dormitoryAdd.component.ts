import { Component} from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { RequestService} from '../../shared/request.service';
import { Dormitory } from './Dormitory';

@Component({
    moduleId: module.id,
    templateUrl: 'dormitoryAdd.component.html'
})
export class DormitoryAddComponent {
    public dormitory: Dormitory;
    private requestService : RequestService;
    myRouter: Router;

    constructor(private router: Router, private activateRoute: ActivatedRoute, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs;
        this.dormitory = new Dormitory();
    }

    Done(myItem: Dormitory) {
        this.requestService.post('dormitories', myItem).subscribe((resp: any) => {
            this.dormitory = resp.json();
            this.myRouter.navigate(['dormitory']);
        });
    }
}