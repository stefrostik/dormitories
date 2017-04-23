import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';
import { Block } from './Block';
import { Router } from '@angular/router';


@Component({
    moduleId: module.id,
    templateUrl: 'blocks.component.html'
})
export class BlockComponent {
    public blocks: Block[];
    requestService: RequestService;
    myRouter: Router;

    constructor(private router: Router, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs;
        this.requestService.get('blocks').subscribe(result => {
            this.blocks = result.json();
        });
    }

    Delete(id: number) {
        this.requestService.delete('blocks/' + id).subscribe((resp: any) => {
            this.blocks = this.blocks.filter(x => x.Id !== id);
        });
    }
}






