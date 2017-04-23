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
const core_1 = require("@angular/core");
const router_1 = require("@angular/router");
const request_service_1 = require("../../shared/request.service");
const Floor_1 = require("./Floor");
let FloorEditComponent = class FloorEditComponent {
    constructor(router, activateRoute, rs) {
        this.router = router;
        this.activateRoute = activateRoute;
        this.myRouter = router;
        this.requestService = rs;
        this.id = activateRoute.snapshot.params['id'];
        this.floor = new Floor_1.Floor();
        this.requestService.get('floors/' + this.id).subscribe((result) => {
            this.floor = result.json();
        });
    }
    Done(myItem) {
        this.requestService.put('floors', myItem).subscribe((resp) => {
            this.myRouter.navigate(['floor']);
        });
    }
};
FloorEditComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        templateUrl: 'floorEdit.component.html'
    }),
    __metadata("design:paramtypes", [router_1.Router, router_1.ActivatedRoute, request_service_1.RequestService])
], FloorEditComponent);
exports.FloorEditComponent = FloorEditComponent;
//# sourceMappingURL=floorEdit.component.js.map