# tutorat
# Apporter des modifs à la bd
cd /c/Users/yassi/OneDrive/Desktop/tutorat
dotnet build
dotnet ef migrations add [TonNomDeMigration] --project data --startup-project tutorat
dotnet ef database update --project data --startup-project tutorat
