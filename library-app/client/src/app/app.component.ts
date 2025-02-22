// filepath: /Users/richardfrench/Documents/git/library-app/client/src/app/app.component.ts
import { Component } from '@angular/core';
import { AuthService } from './services/auth.service';
import { User } from '../models/user.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'library-app';
  currentUser: User | null = null;

  constructor(private authService: AuthService) {
    this.currentUser = this.authService.getCurrentUser();
  }

  logout(): void {
    this.authService.logout();
    this.currentUser = null;
  }
}