import { Component, OnInit } from '@angular/core';
import {GroupService} from "../shared/group.service";
import {IGroup} from "../shared/group.interface";
import {AbstractControl, FormControl, FormGroup, Validators} from "@angular/forms";
import {FacultyService} from "../shared/faculty.service";
import {StudentService} from "../shared/student.service";

@Component({
  selector: 'app-university-app-group-page',
  templateUrl: './university-app-group-page.component.html',
  styleUrls: ['./university-app-group-page.component.css'],
  providers: [
    GroupService,
    FacultyService,
    StudentService
  ]
})
export class UniversityAppGroupPageComponent implements OnInit {

  groups: IGroup[] = [];
  item: number = 0;
  public formGroup!: FormGroup;
  
  constructor(private groupService: GroupService, private facultyService: FacultyService) {
    this.updateInfo();
  }

  ngOnInit(): void {
    this.formGroup = new FormGroup({
      id: new FormControl(0, [Validators.required]),
      name: new FormControl(null, [Validators.required]),
      facultyId: new FormControl(null, [Validators.required])
    });
  }

  public updateInfo() {
    this.groupService.getGroups().subscribe((raw) => this.groups = raw );    
  }

  public deleteGroup(group: IGroup) {
    this.groupService.deleteGroup(group.id).subscribe( () => this.updateInfo() );
  }

  public createGroup() {
    if (this.formGroup.invalid) {
      return;
    }

    this.facultyService.getFacultyByName(this.facultyNameControl.value).subscribe( (raw) => this.item = raw.id);
    setTimeout(() => {
      this.groupService.addGroup({
        id: 0,
        name: this.nameGroupControl.value,
        facultyId: this.item
      }).subscribe(() => {
        this.updateInfo();
        this.nameGroupControl.setValue(null);
        this.facultyNameControl.setValue(null);
        this.formGroup.markAsUntouched();
      });
    }, 200);
  }
  
  get nameGroupControl(): AbstractControl {
    return this.formGroup.get('name')!;
  }

  get facultyNameControl(): AbstractControl {
    return this.formGroup.get('facultyId')!;
  }
}
