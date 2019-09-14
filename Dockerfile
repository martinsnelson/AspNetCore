# FROM microsoft/dotnet:2.2-sdk AS build-env
FROM microsoft/dotnet:2.2-sdk-alpine AS build-env
WORKDIR /app

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
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
WORKDIR /app

COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "AspNetCore.dll"]

CMD sed -i -e 's/$PORT/'"$PORT"'/g' && nginx -g 'daemon off;'