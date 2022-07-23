import {NgModule} from '@angular/core';
import {CommonModule} from '@angular/common';
import {UniversityAppPageComponent} from "./university-app-page/university-app-page.component";
import {UniversityAppRoutingModule} from "./university-app-routing.module";
import {MatTabsModule} from '@angular/material/tabs';
import {MatButtonModule} from "@angular/material/button";
import {MatCardModule} from "@angular/material/card";
import {MatInputModule} from '@angular/material/input';
import {UniversityAppItemComponent} from "./university-app-faculty-item/university-app-faculty-item.component";
import {HttpClientModule} from "@angular/common/http";
import {UniversityAppGroupItemComponent} from './university-app-group-item/university-app-group-item.component';
import {UniversityAppStudentItemComponent} from './university-app-student-item/university-app-student-item.component';
import {MatExpansionModule} from '@angular/material/expansion';
import {ReactiveFormsModule} from "@angular/forms";

@NgModule({
  declarations: [
    UniversityAppPageComponent,
    UniversityAppItemComponent,
    UniversityAppGroupItemComponent,
    UniversityAppStudentItemComponent
  ],
  imports: [
    CommonModule,
    UniversityAppRoutingModule,
    MatTabsModule,
    MatButtonModule,
    MatCardModule,
    HttpClientModule,
    MatInputModule,
    MatExpansionModule,
    ReactiveFormsModule
  ]
})
export class UniversityAppModule {
}
