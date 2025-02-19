// filepath: /Users/richardfrench/Documents/git/library-app/client/src/app/components/book-detail/book-detail.component.ts
import { Component, Input } from '@angular/core';
import { Book } from '../../../models/book.model';

@Component({
  selector: 'app-book-detail',
  templateUrl: './book-detail.component.html',
  styleUrls: ['./book-detail.component.css']
})
export class BookDetailComponent {
  @Input() book: Book | null = null;

  onCheckout() {
    // Implement checkout logic here
  }

  onDelete() {
    // Implement delete logic here
  }
}