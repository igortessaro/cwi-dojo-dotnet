# CWI Dojo .NET - Time de integrações

Este projeto tem como objetivos instigar, compartilhar e desenvolver o conhecimento do time com o .NET.

## Semana 1: Criando projetos usando linha de comando

Criando a pasta do projeto:

```shell
    ❯ mkdir 01-command-line-projects
    ❯ cd 01-command-line-projects
```

Criando a solution que vamos colocar nossos projetos:

```shell
    ❯ dotnet new sln -n DotnetNewProject
```

Criando os projetos

```shell
    ❯ dotnet new webapi -n DotNetNewProject.Application -lang "C#"
    ❯ dotnet sln DotnetNewProject.sln add DotnetNewProject.Application/DotnetNewProject.Application.csproj --solution-folder 01-application
    ❯ dotnet new classlib -n DotnetNewProject.Core -lang "C#"
    ❯ dotnet sln DotnetnewProject.sln add DotnetNewProject.Core/DotnetNewProject.Core.csproj --solution-folder 02-Core
    ❯ dotnet new classlib -n DotnetNewProject.Domain -lang "C#"
    ❯ dotnet sln DotnetNewProject.sln add DotnetNewProject.Domain/DotnetNewProject.Domain.csproj --solution-folder 03-domain
```

Adicionando referências entre os projetos

```shell
    ❯ dotnet add DotnetNewProject.Application/DotnetNewProject.Application.csproj reference DotnetNewProject.Domain/DotnetNewProject.Domain.csproj
    ❯ dotnet add DotnetNewProject.Domain/DotnetNewProject.Domain.csproj reference DotnetNewProject.Core/DotnetNewProject.Core.csproj
```

Adicionando o pacote Newtonsoft.Json no projeto DotnetProject.Application.csproj

```shell
    ❯ dotnet add DotnetNewProject.Application/DotnetNewProject.Application.csproj  package Newtonsoft.Json --version 13.0.1
```

Para rodar o projeto **DotnetProject.Application** basta fazer o _build_ e o _run_ do projeto usando os comandos abaixo:

```shell
    ❯ dotnet build
    ❯ dotnet run --project DotnetNewProject.Application/DotnetNewProject.Application.csproj
```