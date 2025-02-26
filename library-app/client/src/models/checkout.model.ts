export interface Checkout {
    id: number;
    bookId: number;
    userId: number;
    checkoutDate: Date;
    returnDate?: Date; // Optional to indicate if the book has been returned
  }