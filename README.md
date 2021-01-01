# ManagerAuthorBooks
Projeto de gerenciamento de livros

### 🎲 Rodar o projeto usando o docker

```bash
# Clone este repositório
$ git clone <https://github.com/profale/ManagerAuthorBooks.git>

# Abra o projeto no VSCode ou Visual Studio 2019
# Faça um build na aplicação

# Acesse a pasta do projeto pelo terminal/cmd ou powershell ou vscode
$ cd ../ManagerAuthorBooks/ManagerAuthorBooks

# Execute os comandos
$ docker build .
$ docker-compose up --force-recreate

# O servidor inciará na porta:9002 - acesse <http://localhost:9002/api-docs>
# Para visualizar a fila no RabbitMQ - acesse <http://localhost:15672>
# Login e senha estão no arquivo docker-compose.yml

### 🛠 Implementações utilizadas

- [Docker]
- [Redis]
- [RabbitMQ]
- [SqlServer]
- [API Restful .Net Core 3.1]
- [Entity Framework Core]
- [DDD]
- [CQRS]
- [Testes]
- [Logger]
- [FluntValidation]
