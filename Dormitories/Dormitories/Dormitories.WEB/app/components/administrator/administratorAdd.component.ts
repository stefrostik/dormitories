import { Component} from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { RequestService} from '../../shared/request.service';
import { Administrator } from './Administrator';

@Component({
    moduleId: module.id,
    templateUrl: 'administratorAdd.component.html'
})
export class AdministratorAddComponent {
    public administrator: Administrator;
    private requestService : RequestService;
    myRouter: Router;

    constructor(private router: Router, private activateRoute: ActivatedRoute, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs;
        this.administrator = new Administrator();
    }

    Done(myItem: Administrator) {
        this.requestService.post('administrators', myItem).subscribe((resp: any) => {
            this.administrator = resp.json();
            this.myRouter.navigate(['administrator']);
        });
    }
}