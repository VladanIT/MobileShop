import { Injectable } from '@angular/core';
import { User } from 'src/app/models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  person: User[] = [];

  constructor() { }

  signUp() {
    const localStorageContent = localStorage.getItem('users');
    let users = [];

    if (localStorageContent === null){
      users = [];
    } else {
      users = JSON.parse(localStorageContent);
    }

    users.push(this.person);
    localStorage.setItem('users', JSON.stringify(users));
  }
}
