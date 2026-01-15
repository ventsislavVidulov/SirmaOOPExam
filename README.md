# Car Rental Management System

A console-based car rental management application built with C# .NET 8.0, demonstrating OOP principles and clean architecture.

## Features

- **Car Management**: Add, view, update, and retire vehicles from the fleet
- **Customer Management**: Register and manage customer information
- **Rental Orders**: Process car rentals and returns with date tracking

## Project Structure

```
SirmaOOPExam/
├── Core/                    # Business logic layer
│   ├── Interfaces/          # Service and domain interfaces
│   ├── Models/              # Domain models (Car, Customer, RentalOrder)
│   └── Services/            # Business logic services
├── Infrastructure/
│   ├── FileManagment/       # CSV-based persistence
│   │   └── Data/            # CSV data files
│   └── UI/                  # Console UI and menu system
└── Program.cs               # Entry point
```

## Domain Models

- **Car**: Id, Make, Model, Year, Type, Availability (Available/Rented/Under Maintenance/Retired)
- **Customer**: Id, Name
- **RentalOrder**: Id, CarId, CustomerId, StartDate, ExpectedReturnDate

## How to Run

```bash
cd SirmaOOPExam
dotnet run
```

## Menu Navigation

```
Main Menu
├── Manage Orders
│   ├── Rent Car
│   ├── Return Car
│   ├── Display All Orders
│   └── Back
├── Manage Cars
│   ├── Add Car
│   ├── View All Cars
│   ├── Update Car
│   ├── Retire Car
│   └── Back
├── Manage Customers
│   ├── Add Customer
│   └── Back
└── Exit
```

## Technical Details

- **.NET 8.0** with C# 12
- **CSV file storage** with async I/O operations
- **Reflection-based serialization** for object-to-CSV conversion
- **Interface-based design** for loose coupling
- **Menu pattern** with strategy-like option handling

## Architecture

The application follows a layered architecture:

1. **Core Layer** - Business logic, domain models, and service interfaces
2. **Infrastructure Layer** - File management and UI components
3. **Presentation Layer** - Console menus and user interaction