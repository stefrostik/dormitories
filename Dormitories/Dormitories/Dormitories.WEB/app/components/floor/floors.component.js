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
const http_1 = require("@angular/http");
const router_1 = require("@angular/router");
let FloorComponent = class FloorComponent {
    constructor(router, http) {
        this.router = router;
        this.myRouter = router;
        this.myHttp = http;
        http.get('api/Floors').subscribe(result => {
            this.floors = result.json();
        });
    }
    Delete(id) {
        let headers = new http_1.Headers({ 'Content-Type': 'application/json' });
        let options = new http_1.RequestOptions({ headers: headers });
        this.myHttp.delete('api/Floors/' + id, options).subscribe((resp) => {
            id = resp.json();
        });
        this.floors = this.floors.filter(x => x.Id !== id);
    }
};
FloorComponent = __decorate([
    core_1.Component({
        moduleId: module.id,
        selector: 'floors-details',
        templateUrl: 'floors.component.html'
    }),
    __metadata("design:paramtypes", [router_1.Router, http_1.Http])
], FloorComponent);
exports.FloorComponent = FloorComponent;
//# sourceMappingURL=floors.component.js.map