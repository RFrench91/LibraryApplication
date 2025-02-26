export interface Checkout {
    id: number;
    bookTitle: string;
    username: string;
    checkoutDate: Date;
    returnDate?: Date; // Optional to indicate if the book has been returned
  }