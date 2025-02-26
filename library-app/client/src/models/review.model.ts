export interface Review {
    id: number;
    bookId: number;
    userId: string;
    username: string;
    rating: number;
    comment: string;
    createdAt: Date;}