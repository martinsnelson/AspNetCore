#   Informa a partir de qual imagem será gerada a nova imagem
FROM microsoft/dotnet:2.2-sdk-alpine AS build-env
#   Define qual será o diretório de trabalho (lugar onde serão copiados os arquivos, e criadas novas pastas);
WORKDIR /app
#   Expõem uma ou mais portas, isso quer dizer que o container quando iniciado poderá ser acessível através dessas portas;
# EXPOSE 80

#   Copia arquivos ou diretórios locais para dentro da imagem.
COPY ./AspNetCore/ *.csproj ./
#   Especifica que o argumento seguinte será executado, ou seja, realiza a execução de um comando;
RUN dotnet restore
# RUN dotnet ef database update
COPY ./AspNetCore/ ./
RUN dotnet publish -c release -o out

# Build da imagem
FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .

#   Define um comando a ser executado quando um container baseado nessa imagem for iniciado, esse parâmetro pode ser sobrescrito caso o container seja iniciado utilizando alguma informação de comando, como: docker run -d imagem comando, neste caso o CMD da imagem será sobrescrito pelo comando informado;
CMD ASPNETCORE_URLS=http://*:$PORT dotnet out/AspNetCore.dll

# FROM microsoft/dotnet:2.2-sdk-alpine AS build-env
# WORKDIR /app
# EXPOSE 80

# # Copiar csproj e restaurar dependencias
# # COPY *.csproj ./
# COPY ./AspNetCore/ *.csproj ./
# RUN dotnet restore

# # Build da aplicacao
# # COPY . ./
# COPY ./AspNetCore/ ./
# RUN dotnet publish -c release -o out

# # Build da imagem
# FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine
# WORKDIR /app
# EXPOSE 80
# COPY --from=build-env /app/out .
# CMD ASPNETCORE_URLS=http://*:$PORT dotnet 
# Informa qual comando será executado quando um container for iniciado utilizando esta imagem, diferentemente do CMD, o ENTRYPOINT não é sobrescrito, isso quer dizer que este comando será sempre executado.
# ENTRYPOINT ["dotnet", "AspNetCore.dll"]