import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Administrator } from './Administrator';


@Component({
    moduleId: module.id,
    selector: 'administrators-details',
    templateUrl: 'administrators.component.html'
})
export class AdministratorComponent {
    public administrators: Administrator;

    constructor(http: Http) {
        http.get('api/Administrators').subscribe(result => {
            this.administrators = result.json();
        });
    }
}






