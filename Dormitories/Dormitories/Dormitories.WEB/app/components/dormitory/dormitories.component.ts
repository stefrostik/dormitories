import { Component } from '@angular/core';
import { Dormitory } from './Dormitory';
import { RequestService} from '../../shared/request.service';

@Component({
    moduleId: module.id,
    selector: 'dormitories-details',
    templateUrl: 'dormitories.component.html'
})
export class DormitoriesComponent {
    public dormitories: Dormitory;

    constructor(requestService: RequestService) {
        requestService.get('dormitories').subscribe((result:any) => {
            this.dormitories = result.json();
        });
    }
}






