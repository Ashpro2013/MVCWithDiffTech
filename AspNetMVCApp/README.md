# AspNetMVCApp

ASP.NET Core MVC app with the same student CRUD functionality as `VuePostgresTestMVC`, but implemented with **vanilla JavaScript** (`fetch`) instead of Vue/Axios.

## What It Uses

- ASP.NET Core MVC (`net9.0`)
- `DataService` project reference for models, DbContext, and repository
- PostgreSQL connection via `Npgsql.EntityFrameworkCore.PostgreSQL`

## Implemented Features

- List students
- Create student
- Edit student
- Delete student
- Client-side search/filter in the table

## Run

```bash
cd "/Users/mohammedashraf/Experiment/MVC/VuePostgresTestMVC"
dotnet run --project "AspNetMVCApp/AspNetMVCApp.csproj"
```

Open the app URL and navigate to `/Student/StudentView`.

## Notes

- Connection string is configured in `AspNetMVCApp/appsettings.json` as `DefaultConnection`.
- The app expects the PostgreSQL DB/schema used by `DataService` to already exist.

