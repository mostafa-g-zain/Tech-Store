# Tech Store

Tech Store is an e-commerce web application built using ASP.NET Core MVC. It provides a platform for users to browse and purchase the latest tech products, including laptops, smartphones, and accessories.

## Key Features

- **Multi-Layer Architecture:** Clean separation of concerns utilizing Data Access (DAL), Business Logic (BLL), and Presentation (UI) layers.
- **Secure Checkout Flow:** Engineered a persistent shopping cart integrated with the **Stripe API** for secure and seamless payment processing.
- **Administrative Dashboard:** Dedicated admin portal for managing product catalogs, categories, and inventory.
- **User Portal:** Comprehensive user accounts supporting profile configurations and order tracking.
- **Advanced Search & Filtering:** Dynamic product discovery with advanced search filters and category sorting.
- **Responsive UI:** Mobile-first, responsive design implemented with Bootstrap 5.

## Technologies Used
- **.NET 10**
- **ASP.NET Core MVC**
- **Entity Framework Core** for database access
- **Bootstrap 5** for responsive design
- **Font Awesome** for icons

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
