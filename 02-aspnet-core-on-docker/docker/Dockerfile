FROM mcr.microsoft.com/dotnet/core/sdk:2.2 AS build

WORKDIR /src

COPY ./MyDemoApp.csproj ./

RUN dotnet restore

COPY ./ ./

RUN dotnet publish -c Release -o /docker-demo

FROM mcr.microsoft.com/dotnet/core/aspnet:2.2

WORKDIR /docker-demo

COPY --from=build /docker-demo ./

VOLUME [ "./data" ]

EXPOSE 80

ENTRYPOINT [ "/opt/entrypoint.sh" ]

CMD [ "dotnet", "./MyDemoApp.dll" ]
