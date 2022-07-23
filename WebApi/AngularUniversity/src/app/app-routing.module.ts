import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { UniversityAppPageComponent } from "./university-app/university-app-page/university-app-page.component";

const routes: Routes = [
  {
    path: '**',
    component: UniversityAppPageComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
