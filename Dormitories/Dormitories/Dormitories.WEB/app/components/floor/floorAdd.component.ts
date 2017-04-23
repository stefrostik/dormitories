import { Component} from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { Http } from '@angular/http';
import { Floor } from './Floor';



  
@Component({
    moduleId: module.id,
    templateUrl: 'floorAdd.component.html'
})
export class FloorAddComponent { 
     
    public floor:Floor;
    myHttp : Http;
    myRouter: Router;

    constructor(private router: Router, private activateRoute: ActivatedRoute, http: Http) {
        this.myRouter = router;
        this.myHttp = http;
        this.floor = new Floor();

    }
    Done(myItem: Floor){
             
        this.myHttp.post('api/Floors', myItem).subscribe((resp: any) => {
            this.floor = resp.json();
            this.myRouter.navigate(['floor']);    
        });
        
    }
}