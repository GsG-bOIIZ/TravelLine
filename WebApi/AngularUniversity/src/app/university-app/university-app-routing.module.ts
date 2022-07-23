import { RouterModule, Routes } from "@angular/router";
import { NgModule } from "@angular/core";
import { UniversityAppPageComponent } from "./university-app-page/university-app-page.component";

const routes: Routes = [
    {
        path: 'university-app',
        component: UniversityAppPageComponent
    }
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class UniversityAppRoutingModule { }
