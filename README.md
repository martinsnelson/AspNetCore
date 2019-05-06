#   ANGULAR
ng serve --open

#   EF
dotnet ef migrations add Inicial
dotnet ef database update

dotnet ef migrations remove

#   DOWNLOAD IMAGE SQL SERVE
docker pull microsoft/mssql-server-linux

#   CRIAR IMAGEM
docker run -e 'ACCEPT_EULA=Y' -e 'SA_PASSWORD=M1nhaS&nha!' -p 1433:1433 --name sqlserve -d microsoft/mssql-server-linux:2017-latest

dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

docker-compose up -d --no-recreate
docker-compose stop

docker-compose up
docker-compose ps
docker-compose down

docker stop $(docker ps -a -q)

1- "Server=.;Database=DesafioCCAA;Trusted_Connection=True;User Id=sa;Password=M1nhaS&nha!;Integrated Security=false;MultipleActiveResultSets=true"
2- "Server=.;Database=BookStore;Trusted_Connection=True;User Id=sa;Password=q;Integrated Security=false;MultipleActiveResultSets=true"