# Address Book API (.NET Core)

## Overview

A simple .NET Web API for user registration and managing contacts. Users can sign up, log in, and manage their personal address book.

## Features

* Register (create account)
* Login (JWT authentication)
* Add a contact (first name, last name, phone, email, birthdate)
* List all contacts
* Get contact by ID
* Delete a contact

## Tech Stack

* .NET Core (C#)
* Entity Framework Core
* JWT Authentication
* Password hashing

## Prerequisites

* .NET SDK (7 or 8)
* SQL Server or SQLite

## Installation & Run

1. Clone the repo:
2. Update `appsettings.json` with your DB connection string and JWT key:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=AddressBookDb;Trusted_Connection=True;"
  },
  "Jwt": {
    "Key": "YourSecretKeyHere",
    "Issuer": "AddressBookApi",
    "Audience": "AddressBookApi"
  }
}
```

3. Restore, migrate, and run:

```bash
dotnet restore
dotnet ef database update
dotnet run
```

API will run at `https://localhost:5001`

## API Endpoints

### Auth

* `POST /api/auth/register` → Register new user
* `POST /api/auth/login` → Login and get JWT

### Contacts (require JWT)

* `POST /api/contacts` → Add contact
* `GET /api/contacts` → List contacts
* `GET /api/contacts/{id}` → Get by ID
* `DELETE /api/contacts/{id}` → Delete contact

## Testing with Postman

1. Register a new user
2. Login and copy the JWT token
3. Use the token in **Authorization → Bearer Token** for contact endpoints

## Demo

See the recorded video (in repo or attached link) showing API usage in Swagger.

---

I also make a frontend for this API using Angular.