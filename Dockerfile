FROM node:16.10.0 as build-spa
WORKDIR /usr/app
COPY ./src/Frontend/ .
RUN npm install -g @angular/cli
RUN npm install
RUN ng build --prod


FROM mcr.microsoft.com/dotnet/sdk:5.0 as build-dotnet
WORKDIR /usr/app
COPY --from=build-spa /usr/app/dist/grentryControlBasic ./publish/wwwroot
COPY ./src/Backend/ .
RUN dotnet publish --configuration Release -r linux-arm --output publish/



#EXPOSE 5000/tcp

#ENV ASPNETCORE_URLS "http://*:5000"
#ENV ASPNETCORE_ENVIRONMENT "$ENVIRONMENT"

FROM mcr.microsoft.com/dotnet/runtime:6.0-bullseye-slim-arm32v7
WORKDIR /usr/app
COPY --from=build-dotnet /usr/app/publish ./
CMD dotnet /usr/app/Grentry.Control.Basic.dll
