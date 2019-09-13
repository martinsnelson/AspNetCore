#   EF
add package: Microsoft.EntityFrameworkCore.Tools.DotNet
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

https://rogerdudler.github.io/git-guide/index.pt_BR.html


"ConnectionStrings": {
    "SQLConnection": "Server=.;Database=CbaratoMK;Trusted_Connection=True;User Id=cbaratomk;Password=M1nhaS&nha!;Integrated Security=false;MultipleActiveResultSets=true"
    // "SQLConnection": "Server=.;Database=DesafioCCAA;Trusted_Connection=True;User Id=sa;Password=M1nhaS&nha!;Integrated Security=false;MultipleActiveResultSets=true"
  }


GITLAB
Git global setup
git config --global user.name "Nelson Martins"
git config --global user.email "nelsontecti@gmail.com"

Create a new repository
git clone https://gitlab.com/martinsnelson/wacbaratomk.git
cd wacbaratomk
touch README.md
git add README.md
git commit -m "add README"
git push -u origin master

Push an existing folder
cd existing_folder
git init
git remote add origin https://gitlab.com/martinsnelson/wacbaratomk.git
git add .
git commit -m "Initial commit"
git push -u origin master

Push an existing Git repository
cd existing_repo
git remote rename origin old-origin
git remote add origin https://gitlab.com/martinsnelson/wacbaratomk.git
git push -u origin --all
git push -u origin --tags