import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { BookService } from '../../services/book.service';
import { Book } from '../../../models/book.model';
import { AuthService } from '../../services/auth.service';
import { User } from '../../../models/user.model';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: Book[] = [];
  titleFilter: string = '';
  authorFilter: string = '';
  currentUser: User | null = null;
  @Output() bookSelected = new EventEmitter<Book>();

  constructor(private bookService: BookService, private authService: AuthService) {}

  ngOnInit(): void {
    this.authService.currentUser.subscribe(user => {
      this.currentUser = user;
    });
    this.loadRandomBooks();
  }

  loadRandomBooks(): void {
    this.bookService.getRandomBooks().subscribe(books => {
      this.books = books;
    });
  }

  filterBooks(): void {
    if (!this.titleFilter && !this.authorFilter) {
      this.loadRandomBooks();
    } else {
      this.bookService.getBooks(this.titleFilter, this.authorFilter).subscribe(books => {
        this.books = books;
      });
    }
  }

  onTitleFilterChange(title: string): void {
    this.titleFilter = title;
    this.filterBooks();
  }

  onAuthorFilterChange(author: string): void {
    this.authorFilter = author;
    this.filterBooks();
  }

  onSelectBook(book: Book): void {
    this.bookSelected.emit(book);
  }

  checkoutBook(book: Book): void {
    if (this.currentUser && this.currentUser.role === 'Customer') {
      this.bookService.checkoutBook(book.id, this.currentUser.id).subscribe(() => {
        alert('Book checked out successfully!');
        this.filterBooks();
      }, error => {
        alert('Failed to check out book: ' + error.message);
      });
    }
  }

  isBookAvailable(book: Book): void {
    this.bookService.isBookAvailable(book.id).subscribe(isAvailable => {
      if (isAvailable) {
        this.checkoutBook(book);
      } else {
        alert('Book is not available.');
      }
    });
  }
}