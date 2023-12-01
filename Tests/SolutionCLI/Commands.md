### Создать папку решения
```
mkdir SolutionCLI
```

### Перейтив папку решения
```
cd SolutionCLI
```

### Создать файл решения
```
dotnet new sln -n SolutionCLI
```

### Создать проект консольного приложения
```
dotnet new console -n ConsoleAppCLI
```

### Добавить проект консольного приложения в решение
```
dotnet sln SolutionCLI.sln add ConsoleAppCLI/ConsoleAppCLI.csproj
```

### Перейти в папку проекта консольного приложения
```
cd ConsoleAppCLI
```

### Собрать консольное приложение
```
dotnet build
```

### Запустить консольное приложение
```
dotnet run
```

### Публикация консольного приложения
```
dotnet publish -c Release
```