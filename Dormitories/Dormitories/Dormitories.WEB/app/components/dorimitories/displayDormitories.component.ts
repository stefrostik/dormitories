import { Component } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'city',
    template: require('./city.component.html')
})
export class CityFromDatabase {
    public cities;

    constructor(http: Http) {
        http.get('/api/SampleData/Cities').subscribe(result => {
            this.cities = result.json();
        });
    }
}






