import { NgModule, Component } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { HttpModule, JsonpModule } from '@angular/http';
import { DormitoriesComponent } from './components/dormitory/dormitories.component';
import { DormitoryAddComponent } from './components/dormitory/dormitoryAdd.component';
import { DormitoryDetailsComponent } from './components/dormitory/dormitoryDetails.component';
import { FloorComponent } from './components/floor/floors.component';
import { FloorEditComponent } from './components/floor/floorEdit.component';
import { FloorAddComponent } from './components/floor/floorAdd.component';
import { FloorDetailsComponent } from './components/floor/floorDetails.component';
import { BlockComponent } from './components/block/blocks.component';
import { BlockAddComponent } from './components/block/blockAdd.component';
import { BlockDetailsComponent } from './components/block/blockDetails.component';
import { RoomComponent } from './components/room/rooms.component';
import { RoomAddComponent } from './components/room/roomAdd.component';
import { RoomDetailsComponent } from './components/room/roomDetails.component';
import { HomeComponent } from './components/home/home.component';
import { AdministratorsComponent } from './components/administrator/administrators.component';
import { AdminRegisterComponent } from './components/administrator/adminRegister.component';
import { StudentsComponent } from './components/student/students.component';
import { StudentRegisterComponent } from './components/student/studentRegister.component';
import { StudentAddComponent } from './components/student/studentAdd.component';
import { StudentDetailsComponent } from './components/student/studentDetails.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { AdminHomeComponent } from './components/administrator/adminHome.component';
import { AdminInfoComponent } from './components/administrator/adminInfo.component';
import { StudentHomeComponent} from './components/student/studentHome.component';
import { StudentInfoComponent} from './components/student/studentInfo.component';
import { RouterModule, Routes } from '@angular/router';
import { APP_BASE_HREF } from '@angular/common';
import { DropdownModule } from "ngx-dropdown";
import 'rxjs/Rx'


@NgModule({
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        HomeComponent,
        DormitoriesComponent, DormitoryAddComponent, DormitoryDetailsComponent,
        AdministratorsComponent, AdminRegisterComponent, AdminHomeComponent, AdminInfoComponent,
        FloorComponent, FloorEditComponent, FloorAddComponent, FloorDetailsComponent,
        BlockComponent, BlockAddComponent, BlockDetailsComponent,
        RoomComponent, RoomAddComponent, RoomDetailsComponent,
        StudentsComponent, StudentRegisterComponent, StudentDetailsComponent, StudentAddComponent,
        StudentHomeComponent, StudentInfoComponent,
        LoginComponent, RegisterComponent
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
            { path: 'dormitory/dormitoryAdd', component: DormitoryAddComponent },
            { path: 'dormitory/details/:id', component: DormitoryDetailsComponent },
            { path: 'home', component: HomeComponent },
            {
                path: 'admin-home', component: AdminHomeComponent,
                children: [
                    { path: '', redirectTo: 'info', pathMatch: 'full' },
                    { path: 'info', component: AdminInfoComponent },
                    { path: 'administrators', component: AdministratorsComponent},
                    { path: 'addAdmin', component: AdminRegisterComponent },
                    { path: 'students', component: StudentsComponent },
                    { path: 'studentRegister', component: StudentRegisterComponent },
                    { path: 'dormitories', component: DormitoriesComponent },
                    { path: 'dormitoryAdd', component: DormitoryAddComponent}
                    //todo: add other components
                ]
            },
            {
                path: 'student-home', component: StudentHomeComponent,
                children: [
                    { path: '', redirectTo: 'info', pathMatch: 'full' },
                    { path: 'info', component: StudentInfoComponent }
                    //todo: add other components
                ]
            },
            //{ path: 'administrators', component: AdministratorComponent },
            //{ path: 'administrator/administatorAdd', component: AdministratorAddComponent },
            { path: 'room', component: RoomComponent },
            { path: 'room/roomAdd', component: RoomAddComponent },
            { path: 'room/roomAdd/:blockId', component: RoomAddComponent },
            { path: 'room/details/:id', component: RoomDetailsComponent },
            { path: 'block', component: BlockComponent },
            { path: 'block/blockAdd', component: BlockAddComponent },
            { path: 'block/blockAdd/:floorId', component: BlockAddComponent },
            { path: 'block/details/:id', component: BlockDetailsComponent },
            { path: 'floor', component: FloorComponent },
            { path: 'floor/floorEdit/:id', component: FloorEditComponent },
            { path: 'floor/floorAdd', component: FloorAddComponent },
            { path: 'floor/floorAdd/:dormitoryId', component: FloorAddComponent },
            { path: 'floor/details/:id', component: FloorDetailsComponent },
            { path: 'students', component: StudentsComponent },
            { path: 'student/studentRegister', component: StudentRegisterComponent },
            { path: 'student/studentAdd/:roomId', component: StudentAddComponent },
            { path: 'student/details/:id', component: StudentDetailsComponent },
            { path: 'login', component: LoginComponent },
            { path: 'register', component: RegisterComponent },
            { path: '**', redirectTo: 'home' }
        ], { useHash: true })]
})
export class AppModule {

}