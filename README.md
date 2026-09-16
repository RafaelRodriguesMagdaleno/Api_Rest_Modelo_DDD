# API REST com DDD em C#

API REST desenvolvida em **C# com ASP.NET Core**, utilizando uma organização inspirada nos princípios de **Domain-Driven Design (DDD)**. O projeto apresenta um domínio de apostas esportivas, com usuários, depósitos, jogos, apostas e regras de negócio encapsuladas nas entidades e casos de uso.

O nome interno da aplicação é `Unibet`.

## Objetivos

- Demonstrar a construção de uma API REST com ASP.NET Core;
- Organizar o código por responsabilidades relacionadas ao domínio;
- Separar controllers, serviços, casos de uso, repositórios, entidades e objetos de valor;
- Aplicar regras de negócio no domínio, como validação de saldo e criação de apostas;
- Integrar a aplicação a um banco de dados MySQL por meio do Entity Framework Core.

## Arquitetura do projeto

A solução utiliza uma separação por camadas e responsabilidades:

| Diretório | Responsabilidade |
|---|---|
| `Controllers/` | Recebe requisições HTTP e encaminha as operações para serviços ou casos de uso. |
| `Entities/` | Contém as entidades do domínio, como `User`, `Game`, `Bet` e `Deposit`. |
| `ValueObjects/` | Representa conceitos do domínio, como `Amount`, com suas próprias validações. |
| `DTOs/` | Define os objetos usados na entrada de dados das requisições. |
| `UseCases/` | Implementa fluxos específicos do negócio, como a realização de uma aposta. |
| `Services/` | Orquestra operações de aplicação relacionadas aos usuários. |
| `Repositories/` | Centraliza o acesso aos dados persistidos. |
| `Interfaces/` | Define contratos para serviços e repositórios. |
| `Data/Contexts/` | Configura o contexto do Entity Framework Core e o mapeamento das entidades. |

## Domínio

### Usuário

A entidade `User` possui dados cadastrais, saldo e depósitos. O método `Debit` impede que uma aposta seja realizada quando o saldo disponível for insuficiente.

### Jogo

A entidade `Game` representa um jogo com equipes, cotações, data de início e data de encerramento. O método `Place` cria uma aposta associada ao jogo.

### Aposta

A entidade `Bet` registra o jogo, o usuário, o valor apostado e a equipe escolhida.

### Depósito

A entidade `Deposit` representa uma entrada de saldo associada a um usuário. O serviço de usuários valida o valor e o usuário informado antes de preparar o depósito.

### Objeto de valor `Amount`

O objeto `Amount` encapsula um valor monetário e impede a criação de valores menores ou iguais a zero.

## Endpoints disponíveis

Os controllers atuais expõem os seguintes endpoints:

| Método | Rota | Descrição |
|---|---|---|
| `GET` | `/User/GetUserData?Id={id}` | Consulta os dados de um usuário. |
| `POST` | `/User/Deposit` | Recebe os dados de um depósito. |
| `PUT` | `/User/Edit?Id={id}` | Endpoint previsto para edição de usuário. |
| `POST` | `/Game/Place` | Realiza uma aposta para um usuário em um jogo. |

### Exemplo de depósito

```http
POST /User/Deposit
Content-Type: application/json
```

```json
{
  "depositAmount": 100.00,
  "depositType": "Pix",
  "userId": "00000000-0000-0000-0000-000000000000"
}
```

### Exemplo de aposta

```http
POST /Game/Place
Content-Type: application/json
```

```json
{
  "amount": 25.00,
  "gameId": "00000000-0000-0000-0000-000000000000",
  "userId": "00000000-0000-0000-0000-000000000000",
  "team": "Time A"
}
```

## Fluxo de realização de uma aposta

1. `GameController` recebe uma requisição em `/Game/Place`;
2. O controller encaminha o request para `PlaceUseCase`;
3. O caso de uso busca o usuário e o jogo pelos respectivos repositórios;
4. O saldo do usuário é debitado por meio de `User.Debit`;
5. O jogo registra uma nova aposta com `Game.Place`;
6. O caso de uso solicita a atualização do usuário e do jogo.

## Tecnologias utilizadas

- C#;
- ASP.NET Core Web API;
- .NET 10;
- Entity Framework Core;
- MySQL;
- Swagger/OpenAPI;
- Injeção de dependência nativa do ASP.NET Core.

## Estrutura de arquivos

```text
Api_Rest_Modelo_DDD/
├── LICENSE
├── README.md
└── Unibet/
    ├── Controllers/
    │   ├── GameController.cs
    │   └── UserController.cs
    ├── Data/Contexts/
    │   └── Context.cs
    ├── DTOs/
    │   ├── DepositDTO.cs
    │   └── Request/PlaceRequest.cs
    ├── Entities/
    │   ├── Bet.cs
    │   ├── Deposit.cs
    │   ├── EntitiyBase.cs
    │   ├── Game.cs
    │   └── User.cs
    ├── Interfaces/
    │   ├── IRepositories/
    │   └── IServices/
    ├── Repositories/
    │   └── UserRepository.cs
    ├── Services/
    │   └── UserService.cs
    ├── UseCases/
    │   └── PlaceUseCase.cs
    ├── ValueObjects/
    │   └── Amount.cs
    ├── Program.cs
    ├── Unibet.csproj
    ├── Unibet.slnx
    └── appsettings.json
```

## Pré-requisitos

- [.NET SDK 10](https://dotnet.microsoft.com/download/dotnet/10.0);
- MySQL Server;
- Uma ferramenta para testar APIs, como Swagger UI, Postman ou Insomnia.

Verifique a instalação do .NET com:

```bash
dotnet --version
```

## Configuração do banco de dados

O arquivo `Unibet/appsettings.json` possui as connection strings `Default` e `Develop`, configuradas para um banco MySQL local chamado `unibetdb`.

Antes de executar a API:

1. Instale e inicie o MySQL;
2. Crie o banco de dados `unibetdb`;
3. Ajuste usuário, senha, porta e servidor em `appsettings.json`;
4. Confirme se a aplicação possui os pacotes do Entity Framework Core e do provedor MySQL configurados no projeto.

Não versionar senhas ou credenciais reais em arquivos de configuração. Para ambientes compartilhados, prefira variáveis de ambiente ou o Secret Manager do .NET.

## Como executar

Na raiz do repositório, entre na pasta da aplicação:

```bash
cd Unibet
```

Restaure as dependências e compile o projeto:

```bash
dotnet restore
dotnet build
```

Execute a API com:

```bash
dotnet run
```

Durante o desenvolvimento, o Swagger é habilitado e pode ser acessado no endereço exibido pelo terminal, normalmente em uma rota como:

```text
https://localhost:xxxx/swagger
```

As portas exatas dependem das configurações em `Properties/launchSettings.json`.

## Estado atual do projeto

Este repositório apresenta uma base de estudo para uma API com DDD. Algumas partes ainda estão em desenvolvimento:

- `UserService.GetUserData` ainda lança `NotImplementedException`;
- O método de depósito valida e cria o objeto em memória, mas a chamada de persistência está comentada;
- `UserController` possui uma rota `PUT /User/Edit` que ainda reutiliza a consulta de dados e não realiza uma edição completa;
- O repositório de usuários ainda não implementa todas as operações declaradas na interface;
- A configuração do projeto deve ser conferida para garantir que os pacotes do Entity Framework Core e do provedor MySQL estejam declarados no `.csproj`;
- O contexto e as dependências de persistência precisam ser validados antes de utilizar a API em produção.
