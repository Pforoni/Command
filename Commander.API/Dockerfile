FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Commander.API.csproj", "./"]
RUN dotnet restore "Commander.API.csproj"
COPY . .
# WORKDIR "/src/."
# RUN dotnet build "Commander.API.csproj" -c Release -o /app/build

# FROM build AS publish
RUN dotnet publish "Commander.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "Commander.API.dll"]

#Construir a imagem:
#docker build -t pforoni/commander:v3 .

#Criar rede docker
#docker network create <name>

#Lista redes do docker
#docker network ls

#Cria container mongo adicionando a rede net5tutorial
#docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 mongo
#docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db -e MONGO_INITDB_ROOT_USERNAME=mongoadmin -e MONGO_INITDB_ROOT_PASSWORD=Pass#word1 --network=net5tutorial mongo

#Cria container da api se comunicando com o mongodb
#docker run -it --rm -p 8080:80 -e MongoDbSettings:Host=mongo -e MongoDbSettings:DatabaseName=ExampleDatabase -e MongoDbSettings:DatabaseName=ExampleDatabase -e MongoDbSettings:Password=Pass#word1 --network=net5tutorial commander:v1

#Prepara a imagem para Upload image p/ docker hub
#docker tag <nameimage:version> pforoni/<nameimage:version>

#Push image to docker Hub
#docker push pforoni/<nameimage:version>