#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src

COPY ["TeacherWorkout.Migrator/TeacherWorkout.Migrator.csproj", "TeacherWorkout.Migrator/"]
COPY ["TeacherWorkout.Data/TeacherWorkout.Data.csproj", "TeacherWorkout.Data/"]
COPY ["TeacherWorkout.Domain/TeacherWorkout.Domain.csproj", "TeacherWorkout.Domain/"]

RUN dotnet restore "TeacherWorkout.Migrator/TeacherWorkout.Migrator.csproj"

COPY ["TeacherWorkout.Migrator", "TeacherWorkout.Migrator/"]
COPY ["TeacherWorkout.Data", "TeacherWorkout.Data/"]
COPY ["TeacherWorkout.Domain", "TeacherWorkout.Domain/"]

WORKDIR "/src/TeacherWorkout.Migrator"
RUN dotnet build "TeacherWorkout.Migrator.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "TeacherWorkout.Migrator.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "TeacherWorkout.Migrator.dll"]
