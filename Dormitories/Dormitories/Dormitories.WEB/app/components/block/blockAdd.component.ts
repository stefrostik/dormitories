import { Component} from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { RequestService} from '../../shared/request.service';
import { Block } from './Block';

@Component({
    moduleId: module.id,
    templateUrl: 'blockAdd.component.html'
})
export class BlockAddComponent {
    public block: Block;
    private requestService : RequestService;
    myRouter: Router;

    constructor(private router: Router, private activateRoute: ActivatedRoute, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs;
        this.block = new Block();
        this.block.FloorId = activateRoute.snapshot.params['floorId'];
        this.Done(this.block);
    }

    Done(myItem: Block) {
        this.requestService.post('blocks', myItem).subscribe((resp: any) => {
            this.block = resp.json();
            this.myRouter.navigate(['floor/details/' + myItem.FloorId]);
        });
    }
}