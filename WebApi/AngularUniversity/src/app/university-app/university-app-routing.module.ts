import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { UniversityAppPageComponent } from "./university-app-page/university-app-page.component";
import {UniversityAppFacultyPageComponent} from "./university-app-faculty-page/university-app-faculty-page.component";
import {UniversityAppGroupPageComponent} from "./university-app-group-page/university-app-group-page.component";
import {UniversityAppStudentPageComponent} from "./university-app-student-page/university-app-student-page.component";

const routes: Routes = [
    {
        path: 'main',
        component: UniversityAppPageComponent
    },
    {
        path: 'faculty',
        component: UniversityAppFacultyPageComponent
    },
    {
        path: 'group',
        component: UniversityAppGroupPageComponent
    },
    {
        path: 'student',
        component: UniversityAppStudentPageComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class UniversityAppRoutingModule { }
