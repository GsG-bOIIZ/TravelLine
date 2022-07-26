import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {IStudent} from "../shared/student.interface";
import {StudentService} from "../shared/student.service";
import {AbstractControl, FormControl, FormGroup, Validators} from "@angular/forms";
import {UniversityAppStudentPageComponent} from "../university-app-student-page/university-app-student-page.component";
import {GroupService} from "../shared/group.service";

@Component({
  selector: 'uni-student-item',
  templateUrl: './university-app-student-item.component.html',
  providers: [
    StudentService,
    GroupService
  ]
})
export class UniversityAppStudentItemComponent implements OnInit {

  constructor(private studentService: StudentService, private groupService: GroupService, private universityAppStudentPageComponent: UniversityAppStudentPageComponent) {
  }

  @Input() public student!: IStudent;
  @Output() public delete: EventEmitter<IStudent> = new EventEmitter<IStudent>();

  public formUpdateStudent!: FormGroup;
  item: number = 0;
  
  public deleteStudent() {
    this.delete.emit(this.student);
  }

  ngOnInit(): void {
    this.formUpdateStudent = new FormGroup({
      id: new FormControl(0, [Validators.required]),
      surname: new FormControl(null, [Validators.required]),
      name: new FormControl(null, [Validators.required]),
      patronymic: new FormControl(null, [Validators.required]),
      age: new FormControl(null, [Validators.required]),
      classId: new FormControl(null, [Validators.required])
    });
  }

  public updateStudent(student: IStudent) {
    if (this.formUpdateStudent.invalid) {
      return;
    }
    this.groupService.getGroupByName(this.groupNameControl.value).subscribe( (raw) => this.item = raw.id);
    setTimeout(() => {
      this.studentService.updateStudent({
        id: student.id,
        surname: this.surnameStudentControl.value,
        name: this.nameStudentControl.value,
        patronymic: this.patronymicStudentControl.value,
        age: this.ageStudentControl.value,
        classId: this.item
      }).subscribe(() => {
        this.universityAppStudentPageComponent.updateInfo();
        this.surnameStudentControl.setValue(null);
        this.nameStudentControl.setValue(null);
        this.patronymicStudentControl.setValue(null);
        this.ageStudentControl.setValue(null);
        this.groupNameControl.setValue(null);
        this.formUpdateStudent.markAsUntouched();
      });
    }, 200);
  }

  get surnameStudentControl(): AbstractControl {
    return this.formUpdateStudent.get('surname')!;
  }

  get nameStudentControl(): AbstractControl {
    return this.formUpdateStudent.get('name')!;
  }

  get patronymicStudentControl(): AbstractControl {
    return this.formUpdateStudent.get('patronymic')!;
  }

  get ageStudentControl(): AbstractControl {
    return this.formUpdateStudent.get('age')!;
  }

  get groupNameControl(): AbstractControl {
    return this.formUpdateStudent.get('classId')!;
  }

}
