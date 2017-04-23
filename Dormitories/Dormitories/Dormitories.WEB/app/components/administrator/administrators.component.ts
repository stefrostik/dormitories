import { Component } from '@angular/core';
import { RequestService} from '../../shared/request.service';
import { Administrator } from './Administrator';

@Component({
    moduleId: module.id,
    selector: 'administrators-details',
    templateUrl: 'administrators.component.html'
})

export class AdministratorComponent {
    public administrators: Administrator;

    constructor(rs: RequestService) {
        rs.get('administrators').subscribe((result: any) => {
            this.administrators = result.json();
        });
    }
}






