import { Component} from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { RequestService} from '../../shared/request.service';
import { Floor } from './Floor';

@Component({
    moduleId: module.id,
    templateUrl: 'floorAdd.component.html'
})
export class FloorAddComponent {
    public floor: Floor;
    private requestService : RequestService;
    myRouter: Router;

    constructor(private router: Router, private activateRoute: ActivatedRoute, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs; 
        this.floor = new Floor();
        this.floor.DormitoryId = activateRoute.snapshot.params['dormitoryId'];
    }

    Done(myItem: Floor){
        this.requestService.post('floors', myItem).subscribe((resp: any) => {
            this.floor = resp.json();
            this.myRouter.navigate(['dormitory/details/' + myItem.DormitoryId]);
        });
    }
}