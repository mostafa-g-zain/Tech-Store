# Tech Store

Tech Store is an e-commerce web application built using ASP.NET Core MVC. It provides a platform for users to browse and purchase the latest tech products, including laptops, smartphones, and accessories.

## Features
- Product catalog with category filtering
- Product details with specifications and reviews
- Responsive design using Bootstrap 5
- Privacy policy page

## Technologies Used
- **.NET 10**
- **ASP.NET Core MVC**
- **Entity Framework Core** for database access
- **Bootstrap 5** for responsive design
- **Font Awesome** for icons

## Database Schema

The application uses the following database structure:

![ERD](https://github.com/user-attachments/assets/d4e8f4e5-8b4a-4f4e-9c5e-8b4a4f4e9c5e)

### Main Entities
- **AspNetUsers** - User authentication and authorization
- **Products** - Product catalog with details
- **Categories** - Product categorization (hierarchical)
- **ProductImages** - Product image gallery
- **Specifications** - Product technical specifications
- **Reviews** - Customer product reviews
- **Orders** - Customer orders
- **OrderItems** - Individual items in orders
- **ShoppingCart** - User shopping cart
- **Wishlist** - User wishlist/favorites
- **Addresses** - User shipping addresses
- **Payments** - Payment transaction records

## Getting Started

### Prerequisites
- Visual Studio 2026
- .NET SDK 10.x
- SQL Server (LocalDB or Developer Edition)

### Setup
1. Clone the repository:
   ```bash
   git clone https://github.com/Mostafa-G-Zain/Tech-Store.git
   ```
2. Open the solution in Visual Studio.
3. Apply migrations to set up the database:
   ```bash
   dotnet ef database update
   ```
4. Run the application:
   ```bash
   dotnet run
   ```
