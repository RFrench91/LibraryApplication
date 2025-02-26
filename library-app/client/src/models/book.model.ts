export interface Book {
  id: number;
  title: string;
  author: string;
  isbn: string;
  publishedDate: Date;
  genre: string;
  coverImageUrl: string; // New field
  numberOfPages: number; // New field
  publisher: string; // New field
  description: string; // New field
  isAvailable: boolean;
  averageRating: number;
}