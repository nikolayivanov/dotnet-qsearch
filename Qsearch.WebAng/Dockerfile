FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["Qsearch.WebAng/Qsearch.WebAng.csproj", "Qsearch.WebAng/"]
RUN dotnet restore "Qsearch.WebAng/Qsearch.WebAng.csproj"
COPY . .
WORKDIR "/src/Qsearch.WebAng"
RUN dotnet build "Qsearch.WebAng.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Qsearch.WebAng.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Qsearch.WebAng.dll"]