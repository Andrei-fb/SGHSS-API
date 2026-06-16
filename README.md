# SGHSS - Sistema de Gestão Hospitalar e de Serviços de Saúde

## Descrição

Sistema desenvolvido para a instituição VidaPlus com o objetivo de centralizar o gerenciamento de pacientes, profissionais de saúde, consultas, prontuários, internações, exames e controle de usuários.

## Tecnologias Utilizadas

* .NET 8
* ASP.NET Core Web API
* Entity Framework Core
* MySQL
* Docker
* VS Code
* Swagger
* JWT
* BCrypt
* Git
* GitHub

## Funcionalidades

### Pacientes

* Cadastro
* Consulta
* Atualização
* Exclusão

### Profissionais de Saúde

* Cadastro
* Consulta
* Atualização
* Exclusão

### Consultas

* Agendamento de consultas presenciais e telemedicina

### Prontuários

* Registro de diagnóstico
* Prescrições médicas

### Internações

* Controle de leitos

### Exames

* Registro de exames e resultados

### Usuários

* Cadastro
* Login

### Segurança

* Senhas criptografadas com BCrypt
* Autenticação JWT
* Controle de acesso por perfil

### Auditoria

* Registro de logs de auditoria

## Banco de Dados

MySQL utilizando Entity Framework Core e Migrations.

## Documentação

A API é documentada através do Swagger.

## Como executar o projeto

### Pré-requisitos

Antes de executar o sistema, é necessário ter instalado:

* .NET 8 SDK
* Docker Desktop
* Git
* Visual Studio Code ou outra IDE compatível

### 1. Clonar o repositório

```bash
git clone https://github.com/Andrei-fb/SGHSS-API.git
cd SGHSS-API
```

### 2. Subir o banco de dados MySQL com Docker

```bash
docker run -d --name mysql_sghss -p 3306:3306 -e MYSQL_ROOT_PASSWORD=123456 -e MYSQL_DATABASE=sghss_db mysql:8.0
```

Caso o container já exista, execute:

```bash
docker start mysql_sghss
```

### 3. Restaurar os pacotes do projeto

```bash
dotnet restore
```

### 4. Aplicar as migrations no banco de dados

```bash
dotnet ef database update
```

### 5. Executar a API

```bash
dotnet run
```

### 6. Acessar o Swagger

Com a API em execução, acesse no navegador o endereço exibido pelo comando `dotnet run`, seguido de `/swagger`.

Exemplo:

```text
http://localhost:5100/swagger
```

**Importante:** a porta pode variar dependendo da configuração do ambiente. Portanto, deve ser utilizada a porta informada pelo comando `dotnet run`.

### 7. Testar autenticação

Primeiramente, cadastre um usuário administrador através do endpoint:

```text
POST /api/Auth/registrar
```

Utilize o seguinte JSON:

```json
{
  "nome": "Administrador VidaPlus",
  "email": "admin@vidaplus.com",
  "senha": "123456",
  "perfil": "Administrador"
}
```

Em seguida, realize o login utilizando o endpoint:

```text
POST /api/Auth/login
```

Com o seguinte JSON:

```json
{
  "email": "admin@vidaplus.com",
  "senha": "123456"
}
```

A API retornará um token JWT.

No Swagger, clique em **Authorize** e informe:

```text
Bearer SEU_TOKEN_AQUI
```

Após a autenticação, todos os endpoints protegidos poderão ser utilizados normalmente.

## Autor

Andrei Francisco
