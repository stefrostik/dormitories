import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { DropdownModule } from "ngx-dropdown";
import { RequestService} from './shared/request.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/app.component.html',
    styleUrls: ['app/app.component.css'],
    providers: [RequestService]
})

export class AppComponent {
}
