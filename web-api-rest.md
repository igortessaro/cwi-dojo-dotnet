# Semana 2: Criando Web API usando o padrao REST

Criando a pasta do projeto:

```shell
    ❯ mkdir 02-web-api-rest
    ❯ cd 02-web-api-rest
```

Criando a solution que vamos colocar nossos projetos:

```shell
    ❯ dotnet new sln -n CustomerApi
```

Criando os projetos

```shell
    ❯ dotnet new webapi -n Customer.Application -lang "C#"
    ❯ dotnet sln CustomerApi.sln add Customer.Application/Customer.Application.csproj  --solution-folder 01-application
```

Adicionando o pacote Newtonsoft.Json no projeto DotnetProject.Application.csproj

```shell
    ❯ dotnet add DotnetNewProject.Application/DotnetNewProject.Application.csproj  package Newtonsoft.Json --version 13.0.1
```

Para rodar o projeto **Customer.Application** basta fazer o _build_ e o _run_ do projeto usando os comandos abaixo:

```shell
    ❯ dotnet build
    ❯ dotnet run --project Customer.Application/Customer.Application.csproj
```
