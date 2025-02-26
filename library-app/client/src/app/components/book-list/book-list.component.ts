import { Component, OnInit } from '@angular/core';
import { BookService } from '../../services/book.service';
import { Book } from '../../../models/book.model';
import { AuthService } from '../../services/auth.service';
import { User } from '../../../models/user.model';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LoggingService } from '../../services/logging.service';

@Component({
  selector: 'app-book-list',
  templateUrl: './book-list.component.html',
  styleUrls: ['./book-list.component.css']
})
export class BookListComponent implements OnInit {
  books: Book[] = [];
  filteredBooks: Book[] = [];
  selectedTitle: string = '';
  selectedAuthor: string = '';
  titles: string[] = [];
  authors: string[] = [];
  sortField: string = '';
  sortDirection: 'asc' | 'desc' = 'asc';
  showAvailable: boolean = true;
  currentUser: User | null = null;
  availabilityMap: { [bookId: number]: boolean } = {};
  private selectedBookSubject = new BehaviorSubject<Book | null>(null);
  selectedBook$: Observable<Book | null> = this.selectedBookSubject.asObservable();
  selectedBook: Book | null = null; // Add this line

  constructor(private bookService: BookService, private authService: AuthService, private loggingService: LoggingService) {}

  ngOnInit(): void {
    this.authService.currentUser.subscribe(user => {
      this.currentUser = user;
    });
    this.bookService.getRandomBooks().pipe(
      catchError(error => {
        this.loggingService.logError(`Failed to fetch random books: ${error.message}`);
        return of([]);
      })
    ).subscribe(books => {
      this.books = books;
      this.filteredBooks = books;
      this.titles = [...new Set(books.map(book => book.title))];
      this.authors = [...new Set(books.map(book => book.author))];
    });  }

  loadRandomBooks(): void {
    this.bookService.getRandomBooks().pipe(
      catchError(error => {
        this.loggingService.logError(`Failed to load random books: ${error.message}`);
        return of([]); // Return an observable that emits an empty array
      })
    ).subscribe(books => {
      console.log('Books loaded:', books); // Add this line
      this.books = books;
      this.checkAvailability();
      this.sortBooks();
    });
  }

  filterBooks(): void {
    this.filteredBooks = this.books.filter(book => 
      (this.selectedTitle ? book.title === this.selectedTitle : true) &&
      (this.selectedAuthor ? book.author === this.selectedAuthor : true)
    );
    this.sortBooks();
  }

  onSortFieldChange(field: string): void {
    if (this.sortField === field) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortField = field;
      this.sortDirection = 'asc';
    }
    this.sortBooks();
  }

  onAvailabilityChange(showAvailable: boolean): void {
    this.showAvailable = showAvailable;
    this.filterBooks();
  }

  sortBooks(): void {
    if (this.sortField) {
      this.filteredBooks.sort((a, b) => {
        const fieldA = (a as any)[this.sortField];
        const fieldB = (b as any)[this.sortField];
        if (fieldA < fieldB) {
          return this.sortDirection === 'asc' ? -1 : 1;
        } else if (fieldA > fieldB) {
          return this.sortDirection === 'asc' ? 1 : -1;
        } else {
          return 0;
        }
      });
    }
  }

  setSortField(field: string): void {
    if (this.sortField === field) {
      this.sortDirection = this.sortDirection === 'asc' ? 'desc' : 'asc';
    } else {
      this.sortField = field;
      this.sortDirection = 'asc';
    }
    this.sortBooks();
  }

  compareStrings(a: string, b: string): number {
    const fieldA = a.toLowerCase();
    const fieldB = b.toLowerCase();
    if (fieldA < fieldB) {
      return this.sortDirection === 'asc' ? -1 : 1;
    } else if (fieldA > fieldB) {
      return this.sortDirection === 'asc' ? 1 : -1;
    } else {
      return 0;
    }
  }

  compareNumbers(a: number, b: number): number {
    if (a < b) {
      return this.sortDirection === 'asc' ? -1 : 1;
    } else if (a > b) {
      return this.sortDirection === 'asc' ? 1 : -1;
    } else {
      return 0;
    }
  }

  onSelectBook(book: Book): void {
    this.selectedBookSubject.next(book);
    this.selectedBook = book; // Add this line
  }

  checkAvailability(): void {
    if (Array.isArray(this.books)) {
      this.books.forEach(book => {
        this.bookService.isBookAvailable(book.id).pipe(
          catchError(error => {
            this.loggingService.logError(`Failed to check availability for book ${book.id}: ${error.message}`);
            return [];
          })
        ).subscribe(isAvailable => {
          this.availabilityMap[book.id] = isAvailable;
        });
      });
    }
  }

  checkoutBook(book: Book): void {
    if (this.currentUser && this.currentUser.role === 'Customer') {
      this.bookService.checkoutBook(book.id, this.currentUser.id).pipe(
        catchError(error => {
          this.loggingService.logError(`Failed to check out book ${book.id}: ${error.message}, ${error}`);
          return of(null); // Return an observable that emits null
        })
      ).subscribe(() => {
        alert('Book checked out successfully!');
        this.filterBooks();
      }, error => {
        alert('Failed to check out book: ' + error.message);
      });
    }
  }
}