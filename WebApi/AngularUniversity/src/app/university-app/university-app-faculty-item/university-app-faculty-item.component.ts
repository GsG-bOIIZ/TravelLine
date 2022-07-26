import { Component, EventEmitter, Input, Output, OnInit } from "@angular/core";
import { IFaculty } from "../shared/faculty.interface";
import {AbstractControl, FormControl, FormGroup, Validators} from "@angular/forms";
import {FacultyService} from "../shared/faculty.service";
import {GroupService} from "../shared/group.service";
import {UniversityAppFacultyPageComponent} from "../university-app-faculty-page/university-app-faculty-page.component";
import {IGroup} from "../shared/group.interface";

@Component({
    selector: 'uni-faculty-item',
    templateUrl:'./university-app-faculty-item.component.html',
    providers: [
      FacultyService
    ]
})

export class UniversityAppItemComponent implements OnInit {

    @Input() public faculty!: IFaculty;
    @Input() public group!: IGroup;
    @Output() public delete: EventEmitter<IFaculty> = new EventEmitter<IFaculty>();
    
    groups: IGroup[] = [];
    
    public formUpdateFaculty!: FormGroup;

    constructor(private facultyService: FacultyService, private groupService: GroupService, private universityAppFacultyPageComponent: UniversityAppFacultyPageComponent) {
    }
    
    ngOnInit(): void {
        this.formUpdateFaculty = new FormGroup({
            id: new FormControl(0, [Validators.required]),
            name: new FormControl(null, [Validators.required]),
            dean: new FormControl(null, [Validators.required])
        });
    }
    
    public deleteFacultyClicked() {
        this.delete.emit(this.faculty);
    }

    public updateFaculty(faculty: IFaculty) {

        if (this.formUpdateFaculty.invalid) {
            return;
        }
        this.facultyService.updateFaculty({
            id: faculty.id,
            name: this.nameControlUpdate.value,
            dean: this.deanControlUpdate.value
        }).subscribe(() => {
            this.universityAppFacultyPageComponent.updateInfo();
            this.nameControlUpdate.setValue(null);
            this.deanControlUpdate.setValue(null);
            this.formUpdateFaculty.markAsUntouched();
        });
    }

    public getGroupsWithFacultyId(id: number) {
        this.groupService.getGroupsWithFacultyId(id).subscribe((raw) => this.groups = raw);
    }
    public clearGroups() {
        this.groups = [];
    }
    
    get nameControlUpdate(): AbstractControl {
        return this.formUpdateFaculty.get('name')!;
    }

    get deanControlUpdate(): AbstractControl {
        return this.formUpdateFaculty.get('dean')!;
    }
}