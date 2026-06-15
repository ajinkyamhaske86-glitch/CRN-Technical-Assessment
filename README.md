# CRN Technical Assessment

## Overview
RESTful API built using .NET 8 and ASP.NET Core Web API for Product and Item management.

## Technology Stack

- .NET 8
- ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- JWT Authentication
- Swagger
- FluentValidation
- Serilog
- Docker
- xUnit

## Features

### Product APIs
- Get All Products
- Get Product By Id
- Create Product
- Update Product
- Delete Product

### Item APIs
- Get All Items
- Get Item By Id
- Create Item
- Update Item
- Delete Item

## Security
- JWT Authentication
- Protected Endpoints using Authorize Attribute

## Validation
- FluentValidation for Product validation

## Logging
- Serilog File Logging
- Global Exception Middleware

## Testing
- xUnit Test Project Included

## Docker

Build Docker Image

```bash
docker build -t crnassessmentapi .
```

Run Container

```bash
docker run -p 8080:80 crnassessmentapi
```

## Author

Ajinkya Mhaske
