// filepath: /Users/richardfrench/Documents/git/library-app/client/src/app/services/auth.service.ts
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators';
import { User } from '../../models/user.model';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'http://localhost:5000/api/auth'; // Update with your API URL
  private currentUser: User | null = null;

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<{ token: string, user: User } | null> {
    return this.http.post<{ token: string, user: User }>(`${this.apiUrl}/login`, { username, password })
      .pipe(
        tap(response => {
          if (response) {
            localStorage.setItem('token', response.token);
            this.currentUser = response.user;
          }
        })
      );
  }

  signup(user: User): Observable<User> {
    return this.http.post<User>(`${this.apiUrl}/register`, user);
  }

  logout(): void {
    this.currentUser = null;
    localStorage.removeItem('token');
  }

  getCurrentUser(): User | null {
    return this.currentUser;
  }

  setCurrentUser(user: User): void {
    this.currentUser = user;
  }
}