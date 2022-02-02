import { Component, OnInit } from '@angular/core';
import  { HttpClient, HttpHeaders } from '@angular/common/http';
import  { IUser } from "./app-models/i-user";
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'my-app-web';
  users?: IUser[];
  showUsers: boolean = false;
  selectedUser?:IUser;
  
  constructor(private httpClient: HttpClient){}

  ngOnInit(): void {
      this.users =  [];
      this.getUsers();
  }


  getUsers(): void{
    var url: string  = "https://jsonplaceholder.typicode.com/users";
    this.httpClient.get<IUser[]>(url, { headers: new HttpHeaders({
      'Content-Type': 'application/json',
      'Access-Control-Allow-Origin': '*',
    }) }).subscribe((users: IUser[]) => {
       this.users =  users;
       this.showUsers = true;
    });
  }

  onSelect(user: IUser):void{
    this.selectedUser = { ...user};
  }

  save(user:IUser)
  {
    let userPostUrl: string = `https://jsonplaceholder.typicode.com/users/${user.id}`
    this.httpClient.put<IUser>(
      userPostUrl, 
      { ...user }, 
      {
        headers: this.getHeaders()
    }).subscribe( (user: IUser) =>{ 
      //alert(JSON.stringify(user));
      this.getUsers();
      this.selectedUser = undefined;
    } )
  }

  getHeaders(): HttpHeaders{
      return new HttpHeaders({
        'Content-Type': 'application/json',
        'Access-Control-Allow-Origin': '*',
      });
  }
}
