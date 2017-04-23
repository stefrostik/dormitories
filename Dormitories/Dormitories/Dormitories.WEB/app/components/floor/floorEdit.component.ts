import { Component} from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { RequestService} from '../../shared/request.service';
import { Floor } from './Floor

@Component({
    moduleId: module.id,
    templateUrl: 'floorEdit.component.html'
})
export class FloorEditComponent {
    id: number;
    public floor: Floor;
    requestService: RequestService;
    myRouter: Router;

    constructor(private router: Router, private activateRoute: ActivatedRoute, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs;
        this.id = activateRoute.snapshot.params['id'];
        this.floor = new Floor();
        this.requestService.get('floors/' + this.id).subscribe((result: any) => {
            this.floor = result.json();
        });
    }

    Done(myItem: Floor) {
        this.requestService.put('floors', myItem).subscribe((resp: any) => {
            this.myRouter.navigate(['floor']);
        });
    }
}