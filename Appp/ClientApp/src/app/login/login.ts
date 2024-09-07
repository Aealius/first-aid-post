import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { DataService } from '../data-service';
import { Router } from '@angular/router';

@Component({
  selector: 'login',
  templateUrl: './login.html',
  styleUrls: ['./login.css']
})
export class LoginComponent {
  login = "";
  password = "";
  hide = true;
  isLoginNeed = false;
  isPasswordNeed = false;
  wrongAns = false;
  user: any;

  constructor(private dataService: DataService, private router: Router) {

  }

  enter() {
    let needReturn = false;

    if (!this.login) {
      needReturn = true;
      this.isLoginNeed = true;
    }
    else {
      this.isLoginNeed = false;
    }

    if (!this.password) {
      needReturn = true;
      this.isPasswordNeed = true;
    }
    else {
      this.isPasswordNeed = false;
    }

    if (needReturn) {
      return;
    }

    this.dataService.loginPost(this.login, this.password).subscribe((result: any) => {
      debugger;
      this.user = result;

      if (this.user.userId == -1) {
        this.wrongAns = true;
      }
      else {
        this.wrongAns = false;
        this.dataService.user = this.user;
        this.router.navigate(['/students']);
      }
    })
  }
}
