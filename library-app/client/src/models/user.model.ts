export interface User {
    id: number;
    username: string;
    password: string;
    role: 'Librarian' | 'Customer';
  }