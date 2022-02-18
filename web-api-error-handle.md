# Semana 3: Criando web api com error handler

Criando a pasta do projeto:

```shell
    ❯ mkdir 03-web-api-error-handle
    ❯ cd mkdir 03-web-api-error-handle
```

Criando a solution que vamos colocar nossos projetos:

```shell
    ❯ dotnet new sln -n WebApiErrorHandle
```

Criando os projeto

```shell
    ❯ dotnet new webapi -n WebApiErrorHandle.Application -lang "C#"
    ❯ dotnet sln WebApiErrorHandle.sln add WebApiErrorHandle.Application/WebApiErrorHandle.Application.csproj --solution-folder 01-application
```

Obs: implementacao retirada do artigo [ASP.NET Core 3.1 - Global Error Handler Tutorial](https://jasonwatmore.com/post/2020/10/02/aspnet-core-31-global-error-handler-tutorial#:~:text=The%20global%20error%20handler%20middleware%20is%20used%20catch%20all%20exceptions,Configure%20method%20of%20the%20Startup.)
