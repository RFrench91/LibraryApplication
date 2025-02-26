import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Book } from '../../models/book.model';
import { Checkout } from '../../models/checkout.model';
import { LoggingService } from './logging.service';
import { Review } from '../../models/review.model';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private apiUrl = `${environment.apiUrl}/books`;

  constructor(private http: HttpClient, private loggingService: LoggingService) {}

  getRandomBooks(): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.apiUrl}/random`).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  getBooks(title: string, author: string, available: boolean | null): Observable<Book[]> {
    let params = new HttpParams();
    if (title) {
      params = params.set('title', title);
    }
    if (author) {
      params = params.set('author', author);
    }
    if (available !== null) {
      params = params.set('available', available.toString());
    }
    return this.http.get<Book[]>(this.apiUrl, { params }).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  getBookById(bookId: number): Observable<Book> {
    return this.http.get<Book>(`${this.apiUrl}/${bookId}`).pipe(
      catchError(this.handleError.bind(this))
    );
  }
  addBook(book: Book): Observable<Book> {
    return this.http.post<Book>(this.apiUrl, book).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  updateBook(book: Book): Observable<Book> {
    return this.http.put<Book>(`${this.apiUrl}/${book.id}`, book).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  deleteBook(bookId: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/${bookId}`).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  isBookAvailable(bookId: number): Observable<boolean> {
    return this.http.get<boolean>(`${this.apiUrl}/${bookId}/availability`).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  checkoutBook(bookId: number, userId: string): Observable<Checkout> {
    return this.http.post<Checkout>(`${this.apiUrl}/${bookId}/checkout`, { userId }).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  getCheckedOutBooks(): Observable<Checkout[]> {
    return this.http.get<Checkout[]>(`${this.apiUrl}/checkedout`).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  getCheckedOutBooksByUser(userId: string): Observable<Checkout[]> {
    return this.http.get<Checkout[]>(`${this.apiUrl}/checkedout/${userId}`).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  returnBook(checkoutId: number): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/return`, checkoutId).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  addReview(bookId: number, review: Review): Observable<Review> {
    return this.http.post<Review>(`${this.apiUrl}/${bookId}/reviews`, review).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  getReviews(bookId: number): Observable<Review[]> {
    return this.http.get<Review[]>(`${this.apiUrl}/${bookId}/reviews`).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  private handleError(error: HttpErrorResponse): Observable<never> {
    this.loggingService.logError(`Error occurred: ${error.message}`);
    return throwError('Something bad happened; please try again later.');
  }
}