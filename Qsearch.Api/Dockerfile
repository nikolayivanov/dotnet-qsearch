FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Qsearch.Api/Qsearch.Api.csproj", "Qsearch.Api/"]
COPY ["Qsearch.Core/Qsearch.Core.csproj", "Qsearch.Core/"]
COPY ["Qsearch.Core.Impl/Qsearch.Core.Impl.csproj", "Qsearch.Core.Impl/"]
RUN dotnet restore "Qsearch.Api/Qsearch.Api.csproj"
COPY . .
WORKDIR "/src/Qsearch.Api"
RUN dotnet build "Qsearch.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Qsearch.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Qsearch.Api.dll"]