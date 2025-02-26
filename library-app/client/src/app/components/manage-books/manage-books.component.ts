import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { BookService } from '../../services/book.service';
import { Book } from '../../../models/book.model';
import { AuthService } from '../../services/auth.service';
import { User } from '../../../models/user.model';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';

@Component({
  selector: 'app-manage-books',
  templateUrl: './manage-books.component.html',
  styleUrls: ['./manage-books.component.css']
})
export class ManageBooksComponent implements OnInit {
  books: Book[] = [];
  currentUser: User | null = null;
  newBook: Book = { id: 0, title: '', author: '', isbn: '', publishedDate: new Date(), genre: '', isAvailable: true, averageRating: 0 };

  constructor(private bookService: BookService, private authService: AuthService, private router: Router) {}

  ngOnInit(): void {
    this.authService.currentUser.subscribe(user => {
      this.currentUser = user;
      if (this.currentUser && this.currentUser.role === 'Librarian') {
        this.loadBooks();
      } else {
        this.router.navigate(['/login']);
      }
    });
  }

  loadBooks(): void {
    this.bookService.getBooks('', '', null).subscribe(books => {
      this.books = books;
    });
  }

  addBook(): void {
    this.bookService.addBook(this.newBook).pipe(
      catchError(error => {
        console.error('Failed to add book:', error);
        return of(null);
      })
    ).subscribe(book => {
      if (book) {
        this.books.push(book);
        this.newBook = { id: 0, title: '', author: '', isbn: '', publishedDate: new Date(), genre: '', isAvailable: true, averageRating: 0 };
      }
    });
  }

  editBook(book: Book): void {
    this.bookService.updateBook(book).pipe(
      catchError(error => {
        console.error('Failed to update book:', error);
        return of(null);
      })
    ).subscribe(updatedBook => {
      if (updatedBook) {
        const index = this.books.findIndex(b => b.id === updatedBook.id);
        if (index !== -1) {
          this.books[index] = updatedBook;
        }
      }
    });
  }

  deleteBook(bookId: number): void {
    this.bookService.deleteBook(bookId).pipe(
      catchError(error => {
        console.error('Failed to delete book:', error);
        return of(null);
      })
    ).subscribe(() => {
      this.books = this.books.filter(book => book.id !== bookId);
    });
  }
}