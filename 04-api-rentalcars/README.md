# Project Rental Cars

Web API with simple CRUD

## Database

### Create database

```sql
CREATE DATABASE [rentalcars];

CREATE SCHEMA [RentalCars];

CREATE TABLE [RentalCars].[Car] (
    [Id] INT IDENTITY(1,1) PRIMARY KEY,
    [Type] VARCHAR(255) NOT NULL,
    [ModelYear] VARCHAR(255) NOT NULL,
    [ManufactureYear] VARCHAR(255) NOT NULL,
    [Brand] VARCHAR(255) NOT NULL,
    [Color] VARCHAR(255) NOT NULL,
    [Plate] VARCHAR(255) NOT NULL
);
```

### ConnectionString exemple

```json
  "ConnectionStrings": {
    "RentalCarsDb": "Server=<YOUR_SERVER>;Database=rentalcars;User Id=<YOUR_USER>;Password=<YOUR_PASSWORD>;"
  }
```
