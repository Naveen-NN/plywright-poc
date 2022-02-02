import { Component, Input, OnInit, Output, EventEmitter, OnDestroy } from '@angular/core';
import { IUser } from '../app-models/i-user';

@Component({
  selector: 'app-edit-user',
  templateUrl: './edit-user.component.html',
  styleUrls: ['./edit-user.component.css']
})
export class EditUserComponent implements OnInit, OnDestroy {
 
  @Input() user?: IUser;
  @Output() onSave: EventEmitter<IUser> = new EventEmitter<IUser>();
  constructor() { }

  ngOnInit(): void {

  }

  save()
  {
    this.onSave.emit(this.user);
  }

  ngOnDestroy(): void {
      this.user = undefined;
  }

}
