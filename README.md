# dotnet-todo-api

Simple Todo API.  Based on the CleanArchitecture template, but with the following changes:

- No authentication
- No authorization
- No domain events

## Database

To add a migration:

```ps
dotnet ef migrations add "Initial" --project Todo.Infrastructure --startup-project Todo.Web --output-dir Persistence\Migrations`
```

To remove the last migration:

```ps
ef migrations remove
```

To update the database:

```ps
dotnet ef database update --project Todo.Infrastructure --startup-project Todo.Web
```
