// filepath: /Users/richardfrench/Documents/git/library-app/client/src/app/components/login/login.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username = '';
  password = '';

  constructor(private authService: AuthService, private router: Router) { }

  login(): void {
    this.authService.login(this.username, this.password).subscribe(response => {
      if (response) {
        this.authService.setCurrentUser(response.user);
        this.router.navigate(['/']);
      } else {
        // Handle login error
      }
    });
  }
}