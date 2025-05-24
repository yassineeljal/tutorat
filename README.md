# tutorat
# Apporter des modifs à la bd
dotnet build
dotnet ef migrations add creation --project data --startup-project tutorat
dotnet ef database update --project data --startup-project tutorat
