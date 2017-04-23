import { Component } from '@angular/core';
import { RequestService} from '../../shared/request.service';
import { Dormitory } from './Dormitory';
import { ActivatedRoute, Router} from '@angular/router';

@Component({
    moduleId: module.id,
    templateUrl: 'dormitoryDetails.component.html'
})
export class DormitoryDetailsComponent {
    public dormitory: Dormitory;
    private id : number;

    constructor(private router: Router, private activateRoute: ActivatedRoute, requestService: RequestService) {
        this.id = activateRoute.snapshot.params['id'];
        requestService.get('dormitories/'+this.id).subscribe((result:any) => {
            this.dormitory = result.json();
        });
    }
}






