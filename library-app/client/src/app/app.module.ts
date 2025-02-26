import { ErrorHandler, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { BookListComponent } from './components/book-list/book-list.component';
import { CheckedOutBooksComponent } from './components/checked-out-books/checked-out-books.component';
import { LayoutComponent } from './components/layout/layout.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { BookDetailComponent } from './components/book-detail/book-detail.component';
import { GlobalErrorHandler } from './services/error-handler.service';
import { LoggingService } from './services/logging.service';

@NgModule({
  declarations: [
    AppComponent,
    BookListComponent,
    CheckedOutBooksComponent,
    LayoutComponent,
    LoginComponent,
    SignupComponent,
    BookDetailComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule
  ],
  providers: [ 
    { provide: ErrorHandler, useClass: GlobalErrorHandler},
    LoggingService
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }