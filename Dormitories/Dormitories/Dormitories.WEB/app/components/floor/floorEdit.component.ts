import { Component} from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { Http } from '@angular/http';
import { Floor } from './Floor';



  
@Component({
    moduleId: module.id,
    templateUrl: 'floorEdit.component.html'
})
export class FloorEditComponent { 
     
    id: number;
    public floor:Floor;
    myHttp : Http;
    myRouter: Router;

    constructor(private router: Router, private activateRoute: ActivatedRoute, http: Http) {
        this.myRouter = router;
        this.myHttp = http;
        this.id = activateRoute.snapshot.params['id'];
        this.floor = new Floor();
        http.get('api/Floors/'+this.id).subscribe((result: any) => {
            this.floor = result.json();//new Floor();//(Floor)result.json();

        });

        //todo request floor by id
    }
    Done(myItem: Floor){
             
        this.myHttp.put('api/Floors', myItem).subscribe((resp: any) => {
            this.myRouter.navigate(['floor']);
        });
        
    }
}