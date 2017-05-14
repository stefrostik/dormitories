import { Component} from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { RequestService } from '../../shared/request.service';
import { Administrator } from '../administrator/administrator';
import { Dormitory } from './Dormitory';

@Component({
    moduleId: module.id,
    templateUrl: 'dormitoryAdd.component.html'
})
export class DormitoryAddComponent {
    public dormitory: Dormitory;
    public administrators: Administrator;
    private requestService : RequestService;
    myRouter: Router;

    constructor(private router: Router, private activateRoute: ActivatedRoute, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs;
        this.dormitory = new Dormitory();
        rs.get('administrators').subscribe((result: any) => {
            this.administrators = result.json();
        });
    }

    Done(myItem: Dormitory) {
        this.requestService.post('dormitories', myItem).subscribe((resp: any) => {
            this.dormitory = resp.json();
            this.myRouter.navigate(['../../dormitories'], { relativeTo: this.activateRoute });
        });
    }
}