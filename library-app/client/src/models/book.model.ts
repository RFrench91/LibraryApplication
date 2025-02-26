export interface Book {
  id: number;
  title: string;
  author: string;
  isbn: string;
  publishedDate: Date;
  genre: string;
  isAvailable: boolean;
  averageRating: number;
}