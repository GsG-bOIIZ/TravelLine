import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {IStudent} from "../shared/student.interface";

@Component({
  selector: 'uni-student-item',
  templateUrl: './university-app-student-item.component.html'
})
export class UniversityAppStudentItemComponent implements OnInit {

  constructor() { }

  @Input() public student!: IStudent;
  @Output() public delete: EventEmitter<IStudent> = new EventEmitter<IStudent>();

  public deleteStudent() {
    this.delete.emit(this.student);
  }

  ngOnInit(): void {
  }

}
