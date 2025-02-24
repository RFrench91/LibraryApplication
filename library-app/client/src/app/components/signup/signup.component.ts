// filepath: /Users/richardfrench/Documents/git/library-app/client/src/app/components/signup/signup.component.ts
import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { User } from '../../../models/user.model';

@Component({
  selector: 'app-signup',
  templateUrl: './signup.component.html',
  styleUrls: ['./signup.component.css']
})
export class SignupComponent {
  username = '';
  password = '';
  role: 'Librarian' | 'Customer' = 'Customer';

  constructor(private authService: AuthService, private router: Router) { }

  signup(): void {
    const newUser: User = { id: 0, username: this.username, password: this.password, role: this.role };
    this.authService.signup(newUser).subscribe(user => {
      if (user) {
        this.authService.setCurrentUser(user);
        this.router.navigate(['/login']);
      } else {
        alert('Signup failed');
      }
    });
  }
}