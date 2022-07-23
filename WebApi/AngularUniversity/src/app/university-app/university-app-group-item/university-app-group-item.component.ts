import {Component, EventEmitter, Input, OnInit, Output} from '@angular/core';
import {IGroup} from "../shared/group.interface";

@Component({
  selector: 'uni-group-item',
  templateUrl: './university-app-group-item.component.html'
})
export class UniversityAppGroupItemComponent implements OnInit {

  constructor() { }

  @Input() public group!: IGroup;
  @Output() public delete: EventEmitter<IGroup> = new EventEmitter<IGroup>();

  public deleteGroup() {
    this.delete.emit(this.group);
  }

  ngOnInit(): void {
  }

}
