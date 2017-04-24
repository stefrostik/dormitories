import { Component } from '@angular/core';
import { RequestService} from '../../shared/request.service';
import { Room } from './Room';
import { ActivatedRoute, Router} from '@angular/router';

@Component({
    moduleId: module.id,
    templateUrl: 'roomDetails.component.html'
})
export class RoomDetailsComponent {
    public room: Room;
    private id : number;

    constructor(private router: Router, private activateRoute: ActivatedRoute, requestService: RequestService) {
        this.id = activateRoute.snapshot.params['id'];
        requestService.get('rooms/' + this.id).subscribe((result: any) => {
            this.room = result.json();
        });
    }
}






