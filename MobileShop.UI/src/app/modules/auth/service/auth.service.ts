import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor() { }

  signUp() {
    const localStorageContent = localStorage.getItem('users');
    let users = [];

    if (localStorageContent === null){
      users = [];
    } else {
      users = JSON.parse(localStorageContent);
    }

    users.push(person);
    localStorage.setItem('users', JSON.stringify(users));
  }
}
