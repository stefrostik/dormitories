import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthenticationService } from '../../shared/authentication.service';
import {Registration } from './Registration';
@Component({
    moduleId: module.id,
    templateUrl: 'register.component.html'
})

export class RegisterComponent {
    model: Registration= new Registration();
    loading = false;
    private authenticationService : AuthenticationService;
    constructor(private router: Router, private as: AuthenticationService) {
        this.authenticationService = as;
    }

    register() {
        this.authenticationService.register(this.model);
        console.log("register works");
    }
}

