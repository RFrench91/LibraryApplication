import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BookListComponent } from './components/book-list/book-list.component';
import { CheckedOutBooksComponent } from './components/checked-out-books/checked-out-books.component';
import { LoginComponent } from './components/login/login.component';
import { SignupComponent } from './components/signup/signup.component';
import { LayoutComponent } from './components/layout/layout.component';
import { AuthGuard } from './auth.guard';
import { SearchBooksComponent } from './components/search-books/search-books.component';
import { ManageBooksComponent } from './components/manage-books/manage-books.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'signup', component: SignupComponent },
  { path: '', component: LayoutComponent, canActivate: [AuthGuard], children: [
    { path: '', component: BookListComponent },
    { path: 'checked-out-books', component: CheckedOutBooksComponent },
    { path: 'search-books', component: SearchBooksComponent },
    { path: 'manage-books', component: ManageBooksComponent }, // Add the manage-books route
  ]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }