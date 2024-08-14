Как поднять БД:
docker run --name mishfit_db -p 5435:5432 -e POSTGRES_USER=mishfit_user -e POSTGRES_PASSWORD=password -e POSTGRES_DB=mishfit_db -d postgres:latest

Применить миграции:
dotnet ef database update
