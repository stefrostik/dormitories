import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { Dormitory } from './Dormitory';
import { ActivatedRoute, Router} from '@angular/router';


@Component({
    moduleId: module.id,
    templateUrl: 'dormitoryDetails.component.html'
})
export class DormitoryDetailsComponent {
    public dormitory: Dormitory;
    id : number;
    myHttp :Http;
    myRouter: Router;

    constructor(private router: Router, private activateRoute: ActivatedRoute, http: Http) {
        this.myRouter = router;
        this.myHttp = http;
        this.id = activateRoute.snapshot.params['id'];
        http.get('api/Dormitories/'+this.id).subscribe(result => {
            this.dormitory = result.json();
        });
    }
}






