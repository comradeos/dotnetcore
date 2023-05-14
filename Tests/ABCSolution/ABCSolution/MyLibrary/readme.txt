https://www.youtube.com/watch?v=SiPkYrqJsps

Создаем токен на https://github.com/settings/tokens

Создем library standart -> Class Library (C# Android Linux MacOS Windows Library)

Пишем классы

добавляем nuget.config в корне с содержимым: 

<?xml version="1.0" encoding="utf-8"?>
<configuration>
  <packageSources>
    <clear />
    <add key="github" value="https://nuget.pkg.github.com/имя_пользователя/index.json" />
  </packageSources>
  <packageSourceCredentials>
    <github>
      <add key="Username" value="имя_пользователя" />
      <add key="ClearTextPassword" value="токен" />
    </github>
  </packageSourceCredentials>
</configuration>

dotnet nuget push .\bin\Debug\имя_пакета.nupkg --source "github"

пример 

dotnet nuget push .\bin\Debug\MyLibrary.3.0.0.nupkg --source "github"