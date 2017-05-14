import { Component} from '@angular/core';
import { ActivatedRoute, Router} from '@angular/router';
import { RequestService} from '../../shared/request.service';
import { Room } from './Room';

@Component({
    moduleId: module.id,
    templateUrl: 'roomAdd.component.html'
})
export class RoomAddComponent {
    public room: Room;
    private requestService : RequestService;
    myRouter: Router;

    constructor(private router: Router, private activateRoute: ActivatedRoute, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs;
        this.room = new Room();
        this.room.BlockId = this.activateRoute.snapshot.params['blockId'];
    }

    Done(myItem: Room) {
        this.requestService.post('rooms', myItem).subscribe((resp: any) => {
            this.myRouter.navigate(['../../block-details/' + myItem.BlockId], { relativeTo: this.activateRoute });
        });
    }
}