postgres:
	docker run --name mishfit_db -p 5432:5432 -e POSTGRES_USER=mishfit_user -e POSTGRES_PASSWORD=password -e POSTGRES_DB=mishfit_db -d postgres:latest
migrateup:
	dotnet ef database update
migratedown:
	dotnet ef migrations remove
build:
	docker-compose build
run:
	docker-compose up -d
stop:
	docker-compose down
	
.PHONY: postgres migrateup migratedown build run stop