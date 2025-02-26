export interface Checkout {
    id: number;
    bookTitle: string;
    username: number;
    checkoutDate: Date;
    returnDate?: Date; // Optional to indicate if the book has been returned
  }