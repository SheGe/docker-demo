# -----------------------------------------------------
# Build Stage
# -----------------------------------------------------
FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build

WORKDIR /src

COPY ./MyDemoApp.csproj ./

RUN dotnet restore

COPY ./ ./

RUN dotnet publish -c Release -o /docker-demo

# -----------------------------------------------------
# Runtime Stage - Final image
# -----------------------------------------------------
FROM mcr.microsoft.com/dotnet/core/aspnet:3.0

COPY ./docker/src/opt/entrypoint.sh /opt/entrypoint.sh

WORKDIR /docker-demo

COPY --from=build /docker-demo ./

VOLUME [ "./data" ]

EXPOSE 80

ENTRYPOINT [ "/opt/entrypoint.sh" ]

CMD [ "dotnet", "./MyDemoApp.dll" ]
