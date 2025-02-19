# Library Checkout Application

This project is a library management application that allows users to check out and store books. It consists of an Angular front end and a .NET Core back end, providing a complete solution for managing book data with basic CRUD operations.

## Project Structure

```
library-app
├── client                # Angular front end
│   ├── src
│   │   ├── app
│   │   │   ├── components
│   │   │   │   ├── book-list          # Component for listing books
│   │   │   │   ├── book-detail         # Component for displaying book details
│   │   │   ├── services                # Services for API calls
│   │   │   ├── app.module.ts           # Root module of the Angular application
│   │   ├── assets                      # Static assets (images, stylesheets)
│   │   ├── environments                # Environment-specific configurations
│   │   ├── index.html                  # Main HTML file
│   │   ├── main.ts                     # Main entry point for the Angular application
│   ├── angular.json                    # Angular CLI configuration
│   ├── package.json                    # NPM configuration
│   ├── tsconfig.json                   # TypeScript configuration
├── server                # .NET Core back end
│   ├── Controllers
│   │   ├── BooksController.cs          # Controller for handling book-related requests
│   ├── Models
│   │   ├── Book.cs                     # Model representing a book entity
│   ├── Data
│   │   ├── LibraryContext.cs           # Database context for managing book data
│   ├── Services
│   │   ├── BookService.cs              # Service for business logic related to books
│   ├── Startup.cs                      # Application startup configuration
│   ├── Program.cs                      # Entry point for the .NET Core application
│   ├── appsettings.json                # Application configuration settings
├── .gitignore                          # Git ignore file
└── README.md                           # Project documentation
```

## Getting Started

### Prerequisites

- .NET Core SDK
- Node.js and npm
- Angular CLI

### Installation

1. Clone the repository:
   ```
   git clone <repository-url>
   cd library-app
   ```

2. Navigate to the client directory and install dependencies:
   ```
   cd client
   npm install
   ```

3. Navigate to the server directory and restore dependencies:
   ```
   cd server
   dotnet restore
   ```

### Running the Application

1. Start the back end:
   ```
   cd server
   dotnet run
   ```

2. Start the front end:
   ```
   cd client
   ng serve
   ```

3. Open your browser and navigate to `http://localhost:4200` to view the application.

### Usage

- Users can view a list of books, see details of each book, and perform CRUD operations (Create, Read, Update, Delete) on the book data.

### Contributing

Contributions are welcome! Please open an issue or submit a pull request for any improvements or features.

### License

This project is licensed under the MIT License.