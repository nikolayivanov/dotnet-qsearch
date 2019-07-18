FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Qsearch.Web/Qsearch.Web.csproj", "Qsearch.Web/"]
RUN dotnet restore "Qsearch.Web/Qsearch.Web.csproj"
COPY . .
WORKDIR "/src/Qsearch.Web"
RUN dotnet build "Qsearch.Web.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Qsearch.Web.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Qsearch.Web.dll"]