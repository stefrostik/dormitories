import { Component } from '@angular/core';

@Component({
    selector: 'my-app',
    template: `<h1>Hi {{name}}!</h1>
                <label>Enter name:</label>
                <input [(ngModel)]="name" placeholder="name">`
})
export class AppComponent {
    name = '';
}