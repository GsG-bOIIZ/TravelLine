import { Component, EventEmitter, Input, Output } from "@angular/core";
import { IFaculty } from "../shared/faculty.interface";
import {AbstractControl, FormControl, FormGroup, Validators} from "@angular/forms";

@Component({
    selector: 'uni-faculty-item',
    templateUrl:'./university-app-faculty-item.component.html'
})

export class UniversityAppItemComponent {
    @Input() public faculty!: IFaculty;
    @Output() public delete: EventEmitter<IFaculty> = new EventEmitter<IFaculty>();

    constructor() {
    }
    
    public deleteFaculty() {
        this.delete.emit(this.faculty);
    }
}
