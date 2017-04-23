import { Component } from '@angular/core';
import { RequestService } from '../../shared/request.service';
import { Room } from './Room';
import { Router } from '@angular/router';


@Component({
    moduleId: module.id,
    templateUrl: 'rooms.component.html'
})
export class RoomComponent {
    public rooms: Room[];
    requestService: RequestService;
    myRouter: Router;

    constructor(private router: Router, rs: RequestService) {
        this.myRouter = router;
        this.requestService = rs;
        this.requestService.get('rooms').subscribe(result => {
            this.rooms = result.json();
        });
    }

    Delete(id: number) {
        this.requestService.delete('rooms/' + id).subscribe((resp: any) => {
            this.rooms = this.rooms.filter(x => x.Id !== id);
        });
    }
}






