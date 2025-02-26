import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LoggingService {

  logError(message: string): void {
    // Here you can send the error to your server or log it to the console
    console.error(message);
  }
}