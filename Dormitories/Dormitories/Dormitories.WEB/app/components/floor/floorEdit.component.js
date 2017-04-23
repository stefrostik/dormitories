"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
const core_1 = require('@angular/core');
const router_1 = require('@angular/router');
const http_1 = require('@angular/http');
const Floor_1 = require('./Floor');
let FloorEditComponent = class FloorEditComponent {
    constructor(router, activateRoute, http) {
        this.router = router;
        this.activateRoute = activateRoute;
        this.myRouter = router;
        this.myHttp = http;
        this.id = activateRoute.snapshot.params['id'];
        this.floor = new Floor_1.Floor();
        http.get('api/Floors/' + this.id).subscribe((result) => {
            this.floor = result.json(); //new Floor();//(Floor)result.json();
        });
        //todo request floor by id
    }
    Done(myItem) {
        this.myHttp.put('api/Floors', myItem).subscribe((resp) => {
            this.myRouter.navigate(['floor']);
        });
    }
};
FloorEditComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        templateUrl: 'floorEdit.component.html'
    }), 
    __metadata('design:paramtypes', [router_1.Router, router_1.ActivatedRoute, http_1.Http])
], FloorEditComponent);
exports.FloorEditComponent = FloorEditComponent;
//# sourceMappingURL=floorEdit.component.js.map