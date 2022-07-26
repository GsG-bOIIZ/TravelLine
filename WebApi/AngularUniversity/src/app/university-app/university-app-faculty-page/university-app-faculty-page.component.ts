import {Component, OnInit} from '@angular/core';
import {FacultyService} from "../shared/faculty.service";
import {AbstractControl, FormControl, FormGroup, Validators} from "@angular/forms";
import {IFaculty} from "../shared/faculty.interface";
import {GroupService} from "../shared/group.service";
import {StudentService} from "../shared/student.service";

@Component({
  selector: 'app-university-app-faculty-page',
  templateUrl: './university-app-faculty-page.component.html',
  styleUrls: ['./university-app-faculty-page.component.css'],
  providers: [
    GroupService,
    FacultyService,
    StudentService
  ]
})

export class UniversityAppFacultyPageComponent implements OnInit {
  
  faculties: IFaculty[] = [];  
  
  public formFaculty!: FormGroup;

  constructor(private facultyService: FacultyService) {
    this.updateInfo();
  }

  public ngOnInit(): void {
    this.formFaculty = new FormGroup({
      id: new FormControl(0, [Validators.required]),
      name: new FormControl(null, [Validators.required]),
      dean: new FormControl(null, [Validators.required])
    });    
  }

  public updateInfo() {
    this.facultyService.getFaculties().subscribe((raw) => this.faculties = raw);
  }

  public deleteFaculty(faculty: IFaculty) {
    this.facultyService.deleteFaculty(faculty.id).subscribe( () => this.updateInfo() );
  }

  public createFaculty() {
    if (this.formFaculty.invalid) {
      return;
    }
    this.facultyService.addFaculty({
      id: 0,
      name: this.nameControl.value,
      dean: this.deanControl.value
    }).subscribe(() => {
      this.updateInfo();
      this.nameControl.setValue(null);
      this.deanControl.setValue(null);
      this.formFaculty.markAsUntouched();
    });
  }  
  
  get nameControl(): AbstractControl {
    return this.formFaculty.get('name')!;
  }
  
  get deanControl(): AbstractControl {
    return this.formFaculty.get('dean')!;
  }
}
