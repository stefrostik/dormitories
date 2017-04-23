import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Dormitory } from './Dormitory';


@Component({
    moduleId: module.id,
    selector: 'dormitories-details',
    templateUrl: 'dormitories.component.html'
})
export class DormitoriesComponent {
    public dormitories: Dormitory;

    constructor(http: Http) {
        http.get('api/Dormitories').subscribe(result => {
            this.dormitories = result.json();
        });
    }
}






