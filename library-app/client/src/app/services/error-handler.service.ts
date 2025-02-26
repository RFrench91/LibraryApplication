import { ErrorHandler, Injectable, Injector } from '@angular/core';
import { HttpErrorResponse } from '@angular/common/http';
import { LoggingService } from './logging.service';

@Injectable({
  providedIn: 'root'
})
export class GlobalErrorHandler implements ErrorHandler {

  constructor(private injector: Injector) {}

  handleError(error: any): void {
    const loggingService = this.injector.get(LoggingService);

    if (error instanceof HttpErrorResponse) {
      // Server or connection error happened
      loggingService.logError(`Backend returned code ${error.status}, body was: ${error.message}`);
    } else {
      // Client Error Happend
      loggingService.logError(`An error occurred: ${error.message}`);
    }

    // Always log errors
    console.error(error);
  }
}