@echo off
title This is your first batch script!
echo Welcome to batch scripting!

dotnet restore

echo  packages restored successfully 

dotnet build
echo  packages build successfully 

cd..
SalesOrderManager.DAL

dotnet restore
dotnet build

dotnet ef --help

dotnet tool install --global dotnet-ef --version 6.0.7

dotnet ef --help

dotnet ef database update

cd..
cd SalesOrderManager.Api
dotnet run

echo  browse Application in browser : https://localhost:7039/  