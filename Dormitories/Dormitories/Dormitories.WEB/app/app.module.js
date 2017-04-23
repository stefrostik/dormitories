"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
const core_1 = require("@angular/core");
const platform_browser_1 = require("@angular/platform-browser");
const forms_1 = require("@angular/forms");
const app_component_1 = require("./app.component");
const http_1 = require("@angular/http");
const dormitories_component_1 = require("./components/dormitory/dormitories.component");
const dormitoryDetails_component_1 = require("./components/dormitory/dormitoryDetails.component");
const floors_component_1 = require("./components/floor/floors.component");
const floorEdit_component_1 = require("./components/floor/floorEdit.component");
const floorAdd_component_1 = require("./components/floor/floorAdd.component");
const home_component_1 = require("./components/home/home.component");
const administrators_component_1 = require("./components/administrator/administrators.component");
const router_1 = require("@angular/router");
const ngx_dropdown_1 = require("ngx-dropdown");
require("rxjs/Rx");
let AppModule = class AppModule {
};
AppModule = __decorate([
    core_1.NgModule({
        bootstrap: [app_component_1.AppComponent],
        declarations: [
            app_component_1.AppComponent,
            dormitories_component_1.DormitoriesComponent,
            floors_component_1.FloorComponent,
            home_component_1.HomeComponent,
            administrators_component_1.AdministratorComponent,
            floorEdit_component_1.FloorEditComponent,
            floorAdd_component_1.FloorAddComponent,
            dormitoryDetails_component_1.DormitoryDetailsComponent
        ],
        imports: [
            platform_browser_1.BrowserModule,
            forms_1.FormsModule,
            http_1.HttpModule,
            http_1.JsonpModule,
            ngx_dropdown_1.DropdownModule,
            router_1.RouterModule.forRoot([
                { path: '', redirectTo: 'home', pathMatch: 'full' },
                { path: 'dormitory', component: dormitories_component_1.DormitoriesComponent },
                { path: 'dormitory/details/:id', component: dormitoryDetails_component_1.DormitoryDetailsComponent },
                { path: 'home', component: home_component_1.HomeComponent },
                { path: 'administator', component: administrators_component_1.AdministratorComponent },
                { path: 'floor', component: floors_component_1.FloorComponent },
                { path: 'floor/floorEdit/:id', component: floorEdit_component_1.FloorEditComponent },
                { path: 'floor/floorAdd', component: floorAdd_component_1.FloorAddComponent },
                { path: '**', redirectTo: 'app' }
            ], { useHash: true })
        ]
    })
], AppModule);
exports.AppModule = AppModule;
//# sourceMappingURL=app.module.js.map