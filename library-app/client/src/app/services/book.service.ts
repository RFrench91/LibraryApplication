import { Injectable } from '@angular/core';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Book } from '../../models/book.model';
import { Checkout } from '../../models/checkout.model';

@Injectable({
  providedIn: 'root'
})
export class BookService {
  private apiUrl = 'http://localhost:5000/api/books'; // Update with your API URL

  constructor(private http: HttpClient) {}

  getBooks(title?: string, author?: string): Observable<Book[]> {
    let params = new HttpParams();
    if (title) {
      params = params.set('title', title);
    }
    if (author) {
      params = params.set('author', author);
    }
    return this.http.get<Book[]>(this.apiUrl, { params });
  }

  getRandomBooks(count: number = 5): Observable<Book[]> {
    return this.http.get<Book[]>(`${this.apiUrl}/random?count=${count}`);
  }

  isBookAvailable(bookId: number): Observable<boolean> {
    return this.http.get<boolean>(`${this.apiUrl}/${bookId}/availability`);
  }

  checkoutBook(bookId: number, userId: number): Observable<Checkout> {
    return this.http.post<Checkout>(`${this.apiUrl}/${bookId}/checkout`, userId);
  }

  getCheckedOutBooks(): Observable<Checkout[]> {
    return this.http.get<Checkout[]>(`${this.apiUrl}/checkedout`);
  }

  getCheckedOutBooksByUser(userId: number): Observable<Checkout[]> {
    return this.http.get<Checkout[]>(`${this.apiUrl}/checkedout/${userId}`);
  }

  returnBook(checkoutId: number): Observable<void> {
    return this.http.post<void>(`${this.apiUrl}/return`, checkoutId);
  }
}