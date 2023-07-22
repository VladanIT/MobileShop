import { UserService } from 'src/app/shared/services/user/user.service';
import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/models/user.model';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {

  userDetails: User = {
    id: '',
    firstName: '',
    lastName: '',
    email: '',
    password: '',
    role: 0
  };

  constructor(private userService: UserService, private route: ActivatedRoute, private router: Router) {}

  ngOnInit(): void {
    this.route.paramMap.subscribe({
      next: (params) => {
        const id = params.get('id');
      }
    })
  }

  updateUser() {

  }

  deleteUser(id: string) {

  }

}
