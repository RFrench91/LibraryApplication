import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { User } from '../models/user.model';
import { ChangeDetectorRef } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  currentUser: User | null = null;

  constructor(private authService: AuthService, private cdr: ChangeDetectorRef) {}

  ngOnInit(): void {
    this.authService.currentUser.subscribe(user => {
      this.currentUser = user;
      this.cdr.detectChanges(); // Manually trigger change detection if needed
    });
  }
}