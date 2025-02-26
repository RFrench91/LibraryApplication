import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookListComponent } from './components/book-list/book-list.component';
import { CheckedOutBooksComponent } from './components/checked-out-books/checked-out-books.component';
import { LayoutComponent } from './components/layout/layout.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BookDetailsComponent } from './components/book-detail/book-detail.component';
import { GlobalErrorHandler } from './services/error-handler.service';
import { LoggingService } from './services/logging.service';
import { SearchBooksComponent } from './components/search-books/search-books.component';
import { RouterModule } from '@angular/router';
import { ManageBooksComponent } from './components/manage-books/manage-books.component';
import { AuthInterceptor } from './interceptors/auth.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    BookListComponent,
    CheckedOutBooksComponent,
    LayoutComponent,
    LoginComponent,
    SignupComponent,
    BookDetailsComponent,
    SearchBooksComponent,
    ManageBooksComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    RouterModule
  ],
  providers: [ 
    { provide: ErrorHandler, useClass: GlobalErrorHandler},
    { provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true },
    LoggingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }