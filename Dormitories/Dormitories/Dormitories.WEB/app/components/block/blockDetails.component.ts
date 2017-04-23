import { Component } from '@angular/core';
import { RequestService} from '../../shared/request.service';
import { Block } from './Block';
import { ActivatedRoute, Router} from '@angular/router';

@Component({
    moduleId: module.id,
    templateUrl: 'blockDetails.component.html'
})
export class BlockDetailsComponent {
    public block: Block;
    private id : number;

    constructor(private router: Router, private activateRoute: ActivatedRoute, requestService: RequestService) {
        this.id = activateRoute.snapshot.params['id'];
        requestService.get('blocks/' + this.id).subscribe((result: any) => {
            this.block = result.json();
        });
    }
}






