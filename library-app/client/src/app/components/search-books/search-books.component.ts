import { Component } from '@angular/core';
import { BookService } from '../../services/book.service';
import { Book } from '../../../models/book.model';
import { catchError } from 'rxjs/operators';
import { of } from 'rxjs';
import { LoggingService } from '../../services/logging.service';

@Component({
  selector: 'app-search-books',
  templateUrl: './search-books.component.html',
  styleUrls: ['./search-books.component.css']
})
export class SearchBooksComponent {
  titleFilter: string = '';
  books: Book[] = [];

  constructor(private bookService: BookService, private loggingService: LoggingService) {}

  searchBooks(): void {
    this.bookService.getBooks(this.titleFilter, '', null).pipe(
      catchError(error => {
        this.loggingService.logError(`Failed to search books: ${error.message}`);
        return of([]); // Return an observable that emits an empty array
      })
    ).subscribe(books => {
      this.books = books;
    });
  }
}