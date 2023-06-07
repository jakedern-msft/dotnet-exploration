FROM mcr.microsoft.com/dotnet/sdk:6.0

COPY . .

WORKDIR /src

RUN dotnet publish --self-contained false -o /app

ENTRYPOINT ["/app/src"]