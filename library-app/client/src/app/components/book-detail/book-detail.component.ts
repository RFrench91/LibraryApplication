import { Component, Input, OnInit, OnChanges, SimpleChanges } from '@angular/core';
import { BookService } from '../../services/book.service';
import { Book } from '../../../models/book.model';
import { Review } from '../../../models/review.model';
import { AuthService } from '../../services/auth.service';
import { User } from '../../../models/user.model';
import { BehaviorSubject, Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LoggingService } from '../../services/logging.service';

@Component({
  selector: 'app-book-details',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailsComponent implements OnInit, OnChanges {
  @Input() book: Book | null = null;
  private reviewsSubject = new BehaviorSubject<Review[]>([]);
  reviews$: Observable<Review[]> = this.reviewsSubject.asObservable();
  newReview: Review = { id: 0, bookId: 0, userId: '', username: '', rating: 0, comment: '', createdAt: new Date() };
  currentUser: User | null = null;

  constructor(
    private bookService: BookService,
    private authService: AuthService,
    private loggingService: LoggingService
  ) {}

  ngOnInit(): void {
    this.authService.currentUser.subscribe(user => {
      this.currentUser = user;
    });

    this.loadReviews();
  }

  ngOnChanges(changes: SimpleChanges): void {
    if (changes.book && this.book) {
      this.newReview.bookId = this.book.id;
      this.loadReviews();
    }
  }

  loadReviews(): void {
    if (this.book) {
      this.bookService.getReviews(this.book.id).subscribe(reviews => {
        this.reviewsSubject.next(reviews);
      });
    }
  }

  addReview(): void {
    if (this.currentUser && this.book) {
      this.newReview.userId = this.currentUser.id;
      this.newReview.username = this.currentUser.userName;
      this.newReview.bookId = this.book.id;
      this.newReview.createdAt = new Date();
      this.bookService.addReview(this.newReview.bookId, this.newReview).pipe(
        catchError(error => {
          this.loggingService.logError(`Failed to add review: ${error.message}`);
          return of(null);
        })
      ).subscribe(review => {
        if (review) {
          this.reviewsSubject.next([...this.reviewsSubject.value, review]);
          this.bookService.getBookById(this.newReview.bookId).subscribe(book => {
            if (book !== null) {
              this.book!.averageRating = book.averageRating;
            }
          });
          this.newReview = { id: 0, bookId: this.newReview.bookId, userId: '', username: '', rating: 0, comment: '', createdAt: new Date() };
        }
      });
    }
  }
}