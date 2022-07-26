import { Component, OnInit } from '@angular/core';

import { FacultyService } from "../shared/faculty.service";
import { GroupService } from "../shared/group.service";
import { StudentService } from "../shared/student.service";
import {UniversityAppGroupPageComponent} from "../university-app-group-page/university-app-group-page.component";
import {UniversityAppStudentPageComponent} from "../university-app-student-page/university-app-student-page.component";
import {UniversityAppFacultyPageComponent} from "../university-app-faculty-page/university-app-faculty-page.component";

@Component({
  selector: 'app-university-app-page',
  templateUrl: './university-app-page.component.html',
  styleUrls: ['./university-app-page.component.css'],
  providers: [
    FacultyService,
    GroupService,
    StudentService
  ]
})
export class UniversityAppPageComponent implements OnInit {


    constructor(private studentService: StudentService, private groupService: GroupService, private facultyService: FacultyService) {
    }

    public ngOnInit(): void {

    }

    /*public updateInfo() {
        this.studentService.getStudents().subscribe((raw) => this.universityAppStudentPageComponent.students = raw );
        this.groupService.getGroups().subscribe((raw) => this.universityAppGroupPageComponent.groups = raw );
        this.facultyService.getFaculties().subscribe((raw) => this.universityAppFacultyPageComponent.faculties = raw);
    }*/
}
