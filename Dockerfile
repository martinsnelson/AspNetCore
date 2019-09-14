# FROM microsoft/dotnet:2.2-sdk AS build-env
# FROM microsoft/dotnet:2.2-sdk-alpine AS build-env
FROM microsoft/dotnet:2.2-sdk AS build-env
WORKDIR /app
EXPOSE 80
# Copiar csproj e restaurar dependencias
# COPY *.csproj ./
COPY ./AspNetCore/ *.csproj ./
RUN dotnet restore

# Build da aplicacao
# COPY . ./
COPY ./AspNetCore/ ./
RUN dotnet publish -c Release -o out

# Build da imagem
# FROM microsoft/dotnet:2.2-aspnetcore-runtime
# FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
FROM microsoft/dotnet:2.2-aspnetcore-runtime
WORKDIR /app

COPY --from=build-env /app/out .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet out/AspNetCore.dll
# CMD ASPNETCORE_URLS=http://*:$PORT dotnet

# ENTRYPOINT ["dotnet", "AspNetCore.dll"]