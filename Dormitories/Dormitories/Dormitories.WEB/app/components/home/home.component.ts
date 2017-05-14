import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Dormitory } from '../dormitory/dormitory';
import { RequestService } from '../../shared/request.service';


@Component({
    moduleId: module.id,
    templateUrl: 'home.component.html'
})
export class HomeComponent {
    public dormitories: Dormitory;

    constructor(requestService: RequestService) {
        requestService.get('dormitories').subscribe((result: any) => {
            this.dormitories = result.json();
        });
    }
}






