import { Component } from '@angular/core';
import { Http } from '@angular/http';
 @Component({
    selector: 'my-app',
    templateUrl: 'app.component.html',
    styleUrls: [ 'app.component.css'],
    moduleId: module.id
})
export class AppComponent {
    name = 'Angular 2';
    constructor(http: Http) {
        http.get('/api/test').subscribe(result => {
            var temp = result.json();
        });
    }
}
