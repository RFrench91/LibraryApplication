export interface User {
    id: string;
    userName: string;
    password: string;
    role: 'Librarian' | 'Customer';
  }