import { Component, OnInit } from '@angular/core';
import { BookService } from '../../services/book.service';
import { AuthService } from '../../services/auth.service';
import { Checkout } from '../../../models/checkout.model';
import { User } from '../../../models/user.model';

@Component({
  selector: 'app-checked-out-books',
  templateUrl: './checked-out-books.component.html',
  styleUrls: ['./checked-out-books.component.css']
})
export class CheckedOutBooksComponent implements OnInit {
  checkouts: Checkout[] = [];
  currentUser: User | null = null;

  constructor(private bookService: BookService, private authService: AuthService) {}

  ngOnInit(): void {
    this.authService.currentUser.subscribe(user => {
      this.currentUser = user;
      if (this.currentUser) {
        this.loadCheckedOutBooks(this.currentUser.id);
      }
    });
  }

  loadCheckedOutBooks(userId: number): void {
    this.bookService.getCheckedOutBooksByUser(userId).subscribe(checkouts => {
      this.checkouts = checkouts;
    });
  }

  isOverdue(dueDate: Date): boolean {
    return new Date(dueDate) < new Date();
  }
}