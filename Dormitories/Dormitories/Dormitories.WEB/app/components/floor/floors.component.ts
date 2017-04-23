﻿import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';
import { Floor } from './Floor';
import { Router } from '@angular/router';


@Component({
    moduleId: module.id,
    templateUrl: 'floors.component.html'
})
export class FloorComponent {
    public floors: Floor[];
    requestService: RequestService;
    myRouter: Router;

    constructor(private router: Router, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs;
        this.requestService.get('floors').subscribe(result => {
            this.floors = result.json();
        });
    }

    Delete(id: number) {
        this.requestService.delete('floors/' + id).subscribe((resp: any) => {
            this.floors = this.floors.filter(x => x.Id !== id);
        });   
    }
}






