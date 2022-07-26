import { Component, OnInit } from '@angular/core';
import {StudentService} from "../shared/student.service";
import {UniversityAppStudentItemComponent} from "../university-app-student-item/university-app-student-item.component";
import {IStudent} from "../shared/student.interface";
import {AbstractControl, FormControl, FormGroup, Validators} from "@angular/forms";
import {GroupService} from "../shared/group.service";
import {UniversityAppPageComponent} from "../university-app-page/university-app-page.component";
import {FacultyService} from "../shared/faculty.service";

@Component({
  selector: 'app-university-app-student-page',
  templateUrl: './university-app-student-page.component.html',
  styleUrls: ['./university-app-student-page.component.css'],
  providers: [
    GroupService,
    FacultyService,
    StudentService
  ]
})

export class UniversityAppStudentPageComponent implements OnInit {

  students: IStudent[] = [];
  public formStudent!: FormGroup;
  item: number = 0;
  
  constructor(private studentService: StudentService, private groupService: GroupService) {
    this.updateInfo();
  }

  ngOnInit(): void {
    this.formStudent = new FormGroup({
      id: new FormControl(0, [Validators.required]),
      surname: new FormControl(null, [Validators.required]),
      name: new FormControl(null, [Validators.required]),
      patronymic: new FormControl(null, [Validators.required]),
      age: new FormControl(null, [Validators.required]),
      classId: new FormControl(null, [Validators.required])
    });
  }

  public deleteStudent(student: IStudent) {
    this.studentService.deleteStudent(student.id).subscribe( () => this.updateInfo() );
  }
  
  public updateInfo() {
    this.studentService.getStudents().subscribe((raw) => this.students = raw );
  }

  public createStudent() {
    if (this.formStudent.invalid) {
      return;
    }
    this.groupService.getGroupByName(this.groupNameControl.value).subscribe( (raw) => this.item = raw.id);
    setTimeout(() => {
      this.studentService.addStudent({
        id: 0,
        surname: this.surnameStudentControl.value,
        name: this.nameStudentControl.value,
        patronymic: this.patronymicStudentControl.value,
        age: this.ageStudentControl.value,
        classId: this.item
      }).subscribe(() => {
        this.updateInfo();
        this.surnameStudentControl.setValue(null);
        this.nameStudentControl.setValue(null);
        this.patronymicStudentControl.setValue(null);
        this.ageStudentControl.setValue(null);
        this.groupNameControl.setValue(null);
        this.formStudent.markAsUntouched();
      });
    }, 200);  
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

  get groupNameControl(): AbstractControl {
    return this.formStudent.get('classId')!;
  }
}
