FROM mcr.microsoft.com/dotnet/aspnet:7.0
LABEL version="1.0.0" description="Aplicacao de teste c Docker"
COPY dist /app
WORKDIR /app
EXPOSE 80/tcp
ENTRYPOINT ["dotnet", "dockerContainer.dll"]