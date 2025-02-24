import { Book } from './book.model';

export interface Checkout {
  id: number;
  bookId: number;
  userId: number;
  checkoutDate: Date;
  dueDate: Date;
  isReturned: boolean;
  book: Book;
}