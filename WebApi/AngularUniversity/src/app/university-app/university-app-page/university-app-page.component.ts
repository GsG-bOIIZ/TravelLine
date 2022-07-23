import { Component, OnInit } from '@angular/core';
import { IFaculty } from "../shared/faculty.interface";
import { IGroup } from "../shared/group.interface";
import {IStudent} from "../shared/student.interface";

import { FacultyService } from "../shared/faculty.service";
import { GroupService } from "../shared/group.service";
import {StudentService} from "../shared/student.service";
import { AbstractControl, FormControl, FormGroup, Validators } from "@angular/forms";

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

    faculties: IFaculty[] = [];
    groups: IGroup[] = [];
    students: IStudent[] = [];
    
    public formFaculty!: FormGroup;
    public formGroup!: FormGroup;
    public formStudent!: FormGroup;

    constructor(private facultyService: FacultyService, private groupService: GroupService, private studentService: StudentService) {
        this.updateInfo();
    }

    public ngOnInit(): void {
        this.formFaculty = new FormGroup({
            id: new FormControl(null, [Validators.required]),
            name: new FormControl(null, [Validators.required]),
            dean: new FormControl(null, [Validators.required])
        });
        this.formGroup = new FormGroup({
            id: new FormControl(null, [Validators.required]),
            name: new FormControl(null, [Validators.required]),
            facultyId: new FormControl(null, [Validators.required])
        });
        this.formStudent = new FormGroup({
            id: new FormControl(null, [Validators.required]),
            surname: new FormControl(null, [Validators.required]),
            name: new FormControl(null, [Validators.required]),
            patronymic: new FormControl(null, [Validators.required]),
            age: new FormControl(null, [Validators.required]),
            classId: new FormControl(null, [Validators.required])
        });
    }

    public deleteFaculty(faculty: IFaculty) {
        this.facultyService.deleteFaculty(faculty.id).subscribe( () => this.updateInfo() );
    }
    
    public deleteGroup(group: IGroup) {
        this.groupService.deleteGroup(group.id).subscribe( () => this.updateInfo() );
    }
    
    public deleteStudent(student: IStudent) {
        this.studentService.deleteStudent(student.id).subscribe( () => this.updateInfo() );
    }

    public updateInfo() {
        this.facultyService.getFaculties().subscribe((raw) => this.faculties = raw );
        this.groupService.getGroups().subscribe((raw) => this.groups = raw );
        this.studentService.getStudents().subscribe((raw) => this.students = raw );
    }

    public createFaculty() {
        if (this.formFaculty.invalid) {
            return;
        }
        this.facultyService.addFaculty({
            id: 0,
            name: this.nameFacultyControl.value,
            dean: this.deanControl.value
        }).subscribe(() => {
            this.updateInfo();
            this.idFacultyControl.setValue(null);        
            this.nameFacultyControl.setValue(null);
            this.deanControl.setValue(null);
            this.formFaculty.markAsUntouched();
        });
    }

    public updateFaculty() {
        if (this.formFaculty.invalid) {
            return;
        }
        this.facultyService.updateFaculty({
            id: this.idFacultyControl.value,
            name: this.nameFacultyControl.value,
            dean: this.deanControl.value
        }).subscribe(() => {
            this.updateInfo();
            this.idFacultyControl.setValue(null);
            this.nameFacultyControl.setValue(null);
            this.deanControl.setValue(null);
            this.formFaculty.markAsUntouched();
        });
    }

    public createGroup() {
        if (this.formGroup.invalid) {
            return;
        }
        this.groupService.addGroup({
            id: 0,
            name: this.nameGroupControl.value,
            facultyId: this.facultyIdControl.value
        }).subscribe(() => {
            this.updateInfo();
            this.idGroupControl.setValue(null);
            this.nameGroupControl.setValue(null);
            this.facultyIdControl.setValue(null);
            this.formGroup.markAsUntouched();
        });
    }

    public updateGroup() {
        if (this.formGroup.invalid) {
            return;
        }
        this.groupService.updateGroup({
            id: this.idGroupControl.value,
            name: this.nameGroupControl.value,
            facultyId: this.facultyIdControl.value
        }).subscribe(() => {
            this.updateInfo();
            this.idGroupControl.setValue(null);
            this.nameGroupControl.setValue(null);
            this.facultyIdControl.setValue(null);
            this.formGroup.markAsUntouched();
        });
    }

    public createStudent() {
        if (this.formStudent.invalid) {
            return;
        }
        this.studentService.addStudent({
            id: 0,
            surname: this.surnameStudentControl.value,
            name: this.nameStudentControl.value,
            patronymic: this.patronymicStudentControl.value,
            age: this.ageStudentControl.value,
            classId: this.classIdStudentControl.value
        }).subscribe(() => {
            this.updateInfo();
            this.idStudentControl.setValue(null);
            this.surnameStudentControl.setValue(null);
            this.nameStudentControl.setValue(null);
            this.patronymicStudentControl.setValue(null);
            this.ageStudentControl.setValue(null);
            this.classIdStudentControl.setValue(null);
            this.formGroup.markAsUntouched();
        });
    }

    public updateStudent() {
        if (this.formStudent.invalid) {
            return;
        }
        this.studentService.updateStudent({
            id: this.idStudentControl.value,
            surname: this.surnameStudentControl.value,
            name: this.nameStudentControl.value,
            patronymic: this.patronymicStudentControl.value,
            age: this.ageStudentControl.value,
            classId: this.classIdStudentControl.value
        }).subscribe(() => {
            this.updateInfo();
            this.idStudentControl.setValue(null);
            this.surnameStudentControl.setValue(null);
            this.nameStudentControl.setValue(null);
            this.patronymicStudentControl.setValue(null);
            this.ageStudentControl.setValue(null);
            this.classIdStudentControl.setValue(null);
            this.formGroup.markAsUntouched();
        });
    }

    get idFacultyControl(): AbstractControl {
        return this.formFaculty.get('id')!;
    }

    get idGroupControl(): AbstractControl {
        return this.formGroup.get('id')!;
    }

    get idStudentControl(): AbstractControl {
        return this.formStudent.get('id')!;
    }
    
    get nameFacultyControl(): AbstractControl {
        return this.formFaculty.get('name')!;
    }
    
    get deanControl(): AbstractControl {
        return this.formFaculty.get('dean')!;
    }
    
    get nameGroupControl(): AbstractControl {
        return this.formGroup.get('name')!;
    }
    
    get facultyIdControl(): AbstractControl {
        return this.formGroup.get('facultyId')!;
    }
    
    get surnameStudentControl(): AbstractControl {
        return this.formStudent.get('surname')!;
    }
    
    get nameStudentControl(): AbstractControl {
        return this.formStudent.get('name')!;
    }
    
    get patronymicStudentControl(): AbstractControl {
        return this.formStudent.get('patronymic')!;
    }
    
    get ageStudentControl(): AbstractControl {
        return this.formStudent.get('age')!;
    }
    
    get classIdStudentControl(): AbstractControl {
        return this.formStudent.get('classId')!;
    }
}
