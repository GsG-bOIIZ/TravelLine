import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {IGroup} from "../shared/group.interface";
import {AbstractControl, FormControl, FormGroup, Validators} from "@angular/forms";
import {GroupService} from "../shared/group.service";
import {UniversityAppGroupPageComponent} from "../university-app-group-page/university-app-group-page.component";
import {FacultyService} from "../shared/faculty.service";
import {IStudent} from "../shared/student.interface";
import {StudentService} from "../shared/student.service";

@Component({
  selector: 'uni-group-item',
  templateUrl: './university-app-group-item.component.html',
  providers: [
    GroupService,
    FacultyService,
    StudentService
  ]
})
export class UniversityAppGroupItemComponent implements OnInit {

  constructor(private groupService: GroupService, private facultyService: FacultyService, private studentService: StudentService, 
              private universityAppGroupPageComponent: UniversityAppGroupPageComponent) {
  }

  @Input() public group!: IGroup;
  @Output() public delete: EventEmitter<IGroup> = new EventEmitter<IGroup>();

  students: IStudent[] = [];
  public formUpdateGroup!: FormGroup;
  item: number = 0;

  ngOnInit(): void {
    this.formUpdateGroup = new FormGroup({
      id: new FormControl(0, [Validators.required]),
      name: new FormControl(null, [Validators.required]),
      facultyId: new FormControl(null, [Validators.required])
    });
  }
  
  public deleteGroupClicked() {
    this.delete.emit(this.group);
  }

  public async updateGroupClicked(group: IGroup) {
    if (this.formUpdateGroup.invalid) {
      return;
    }
    this.facultyService.getFacultyByName(this.facultyNameControl.value).subscribe( (raw) => this.item = raw.id);
    setTimeout(() => {
      this.groupService.updateGroup({
        id: group.id,
        name: this.nameGroupControl.value,
        facultyId: this.item
      }).subscribe(() => {
        this.universityAppGroupPageComponent.updateInfo();
        this.nameGroupControl.setValue(null);
        this.facultyNameControl.setValue(null);
        this.formUpdateGroup.markAsUntouched();
      });
    }, 200);    
  }

  public getStudentsWithClassId(id: number) {
    this.studentService.getStudentsWithClassId(id).subscribe((raw) => this.students = raw);
  }
  public clearStudents() {
    this.students = [];
  }

  get nameGroupControl(): AbstractControl {
    return this.formUpdateGroup.get('name')!;
  }

  get facultyNameControl(): AbstractControl {
    return this.formUpdateGroup.get('facultyId')!;
  }

}
