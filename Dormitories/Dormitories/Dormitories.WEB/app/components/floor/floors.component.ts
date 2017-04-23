import { Component } from '@angular/core';
import { Http, Headers, RequestOptions} from '@angular/http';
import { Floor } from './Floor';
import { Router } from '@angular/router';


@Component({
    moduleId: module.id,
    selector: 'floors-details',
    templateUrl: 'floors.component.html'
})
export class FloorComponent {
    public floors: Floor[];
    myHttp: Http;
    myRouter: Router;

    constructor(private router: Router, http: Http) {
        this.myRouter = router;
        this.myHttp = http;
        http.get('api/Floors').subscribe(result => {
            this.floors = result.json();
        });
    }

    Delete(id: number) {
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });

        this.myHttp.delete('api/Floors/' + id, options).subscribe((resp: any) => {
            id = resp.json();
        });
        this.floors = this.floors.filter(x => x.Id !== id);
    }
}






