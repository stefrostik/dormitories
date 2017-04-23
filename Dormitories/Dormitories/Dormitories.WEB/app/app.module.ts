import { NgModule,Component } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpModule, JsonpModule } from '@angular/http';
import { DormitoriesComponent } from './components/dormitory/dormitories.component'; 
import { FloorComponent } from './components/floor/floors.component'; 
import { FloorEditComponent } from './components/floor/floorEdit.component'; 
import { FloorAddComponent } from './components/floor/floorAdd.component'; 
import { HomeComponent } from './components/home/home.component'; 
import { AdministratorComponent } from './components/administrator/administrators.component'; 
import { RouterModule, Routes } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';
import { DropdownModule } from "ngx-dropdown";

@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        DormitoriesComponent,
        FloorComponent,
        HomeComponent,
        AdministratorComponent,
        FloorEditComponent,
        FloorAddComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        JsonpModule,
        DropdownModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'dormitory', component: DormitoriesComponent },
            { path: 'home', component: HomeComponent },
            { path: 'administator', component: AdministratorComponent },
            { path: 'floor', component: FloorComponent },
            { path: 'floor/floorEdit/:id', component: FloorEditComponent },
            { path: 'floor/floorAdd', component: FloorAddComponent },
            { path: '**', redirectTo: 'app' }
        ], { useHash: true })]
    
   
    
})
export class AppModule {
     
}