FROM microsoft/dotnet:2.2-sdk
WORKDIR /app
EXPOSE 80

COPY *.csproj ./
RUN dotnet restore

COPY . ./
RUN dotnet publish -c Release -o out
CMD ASPNETCORE_URLS=http://*:$PORT dotnet out/wacbaratomk.dll
# FROM microsoft/dotnet:2.2-sdk-alpine AS build-env
# WORKDIR /app
# EXPOSE 80

# # Copiar csproj e restaurar dependencias
# # COPY *.csproj ./
# COPY ./AspNetCore/ *.csproj ./
# RUN dotnet restore
# # RUN dotnet ef database update

# # Build da aplicacao
# # COPY . ./
# COPY ./AspNetCore/ ./
# RUN dotnet publish -c release -o out

# # Build da imagem
# FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
# WORKDIR /app

# COPY --from=build-env /app/out .

# CMD ASPNETCORE_URLS=http://*:$PORT dotnet 
# ENTRYPOINT ["dotnet", "AspNetCore.dll"]