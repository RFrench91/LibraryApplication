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
        if (this.currentUser.role === 'Librarian') {
          this.loadAllCheckedOutBooks();
        } else {
          this.loadCheckedOutBooks(this.currentUser.id);
        }
      }
    });
  }

  loadCheckedOutBooks(userId: string): void {
    this.bookService.getCheckedOutBooksByUser(userId).subscribe(checkouts => {
      this.checkouts = checkouts;
    });
  }

  loadAllCheckedOutBooks(): void {
    this.bookService.getCheckedOutBooks().subscribe(checkouts => {
      this.checkouts = checkouts;
    });
  }

  returnBook(checkoutId: number): void {
    this.bookService.returnBook(checkoutId).subscribe(() => {
      this.checkouts = this.checkouts.filter(checkout => checkout.id !== checkoutId);
    });
  }

  isOverdue(dueDate: Date): boolean {
    return new Date(dueDate) < new Date();
  }
}