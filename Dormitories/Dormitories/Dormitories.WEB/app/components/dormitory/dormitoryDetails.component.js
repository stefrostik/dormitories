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
const request_service_1 = require("../../shared/request.service");
const router_1 = require("@angular/router");
let DormitoryDetailsComponent = class DormitoryDetailsComponent {
    constructor(router, activateRoute, requestService) {
        this.router = router;
        this.activateRoute = activateRoute;
        this.id = activateRoute.snapshot.params['id'];
        requestService.get('dormitories/' + this.id).subscribe((result) => {
            this.dormitory = result.json();
        });
    }
};
DormitoryDetailsComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        templateUrl: 'dormitoryDetails.component.html'
    }),
    __metadata("design:paramtypes", [router_1.Router, router_1.ActivatedRoute, request_service_1.RequestService])
], DormitoryDetailsComponent);
exports.DormitoryDetailsComponent = DormitoryDetailsComponent;
//# sourceMappingURL=dormitoryDetails.component.js.map