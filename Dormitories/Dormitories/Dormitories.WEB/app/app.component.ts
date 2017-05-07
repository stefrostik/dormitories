import { Component } from '@angular/core';
import { Http } from '@angular/http';
import { DropdownModule } from "ngx-dropdown";
import { RequestService } from './shared/request.service';
import { AuthenticationService } from './shared/authentication.service';

@Component({
    selector: 'my-app',
    templateUrl: 'app/app.component.html',
    styleUrls: ['app/app.component.css'],
    providers: [RequestService, AuthenticationService]
})

export class AppComponent {
}
