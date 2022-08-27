# dotnet-todo-api

Simple Todo API.  Based on the CleanArchitecture template, but with the following changes:

- No authentication
- No authorization
- No domain events

## Getting Started

Run the API via visual studio or via CLI:

```ps
dotnet run --project .\src\Todo.Web\
```

On start up the following will happen:

- database will be created
- database will be seeded with test data

Swagger UI can then can be seen via: https://localhost:7110/swagger/index.html

## Database

To add a migration:

```ps
dotnet ef migrations add "Initial" --project .\src\Todo.Infrastructure --startup-project .\src\Todo.Web --output-dir Persistence\Migrations`
```

To remove the last migration:

```ps
ef migrations remove
```

To update the database:

```ps
dotnet ef database update --project .\src\Todo.Infrastructure --startup-project .\src\Todo.Web
```
