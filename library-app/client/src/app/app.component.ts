import { Component, OnInit } from '@angular/core';
import { AuthService } from './services/auth.service';
import { User } from '../models/user.model';
import { Book } from '../models/book.model';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  currentUser: User | null = null;
  selectedBook: Book | null = null;

  constructor(private authService: AuthService) {}

  ngOnInit(): void {
    this.authService.currentUser.subscribe(user => {
      this.currentUser = user;
    });
  }

  onBookSelected(book: Book): void {
    this.selectedBook = book;
  }
}