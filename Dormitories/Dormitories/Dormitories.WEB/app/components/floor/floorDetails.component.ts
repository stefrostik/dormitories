import { Component } from '@angular/core';
import { RequestService} from '../../shared/request.service';
import { Floor } from './Floor';
import { ActivatedRoute, Router} from '@angular/router';

@Component({
    moduleId: module.id,
    templateUrl: 'floorDetails.component.html'
})
export class FloorDetailsComponent {
    public floor: Floor;
    private id : number;

    constructor(private router: Router, private activateRoute: ActivatedRoute, requestService: RequestService) {
        this.id = activateRoute.snapshot.params['id'];
        requestService.get('floors/' + this.id).subscribe((result: any) => {
            this.floor = result.json();
        });
    }
}






