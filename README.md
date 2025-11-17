# Challenge Jr - Clean Architecture API

Este é um projeto de API desenvolvido seguindo os princípios da Clean Architecture com .NET 9 e PostgreSQL.

## 🚀 Tecnologias

- **.NET 9**
- **PostgreSQL 15**
- **Entity Framework Core 9**
- **AutoMapper**
- **Swagger/OpenAPI**
- **Docker & Docker Compose**

## 📋 Pré-requisitos

- [Docker](https://www.docker.com/get-started)
- [Docker Compose](https://docs.docker.com/compose/install/)
- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0) (para desenvolvimento)

## 🛠️ Configuração do Ambiente

### 1. Clone o repositório
```bash
git clone <repository-url>
cd challenge_jr
```

### 2. Configure as variáveis de ambiente
```bash
cp .env.example .env
# Edite o arquivo .env se necessário
```

### 3. Inicie o banco de dados PostgreSQL
```bash
# Iniciar apenas o banco de dados
docker-compose up -d postgres

# Ou iniciar banco + PgAdmin
docker-compose up -d
```

### 4. Execute as migrações
```bash
dotnet ef database update --project ChallengeJr.Infra --startup-project ChallengeJr.Api
```

### 5. Execute a aplicação
```bash
dotnet run --project ChallengeJr.Api
```

## 🐳 Docker Services

### PostgreSQL
- **Host:** localhost
- **Porta:** 5432
- **Usuário:** postgres
- **Senha:** postgres
- **Banco de dados:** challengejr_dev

### PgAdmin (Interface gráfica para PostgreSQL)
- **URL:** http://localhost:8080
- **Email:** admin@admin.com
- **Senha:** admin

## 📁 Estrutura do Projeto

```
Challenge_Jr/
├── ChallengeJr.Api/          # Camada de apresentação (Controllers, Program.cs)
├── ChallengeJr.Application/  # Camada de aplicação (Use Cases, DTOs)
├── ChallengeJr.Domain/       # Camada de domínio (Entidades, Interfaces)
├── ChallengeJr.Infra/        # Camada de infraestrutura (EF, Repositories)
├── ChallengeJr.IoC/          # Inversão de controle (DI)
├── init-scripts/             # Scripts de inicialização do banco
├── docker-compose.yml        # Configuração do Docker
└── .env                      # Variáveis de ambiente
```

## 🔄 Comandos Úteis

### Docker
```bash
# Iniciar serviços
docker-compose up -d

# Parar serviços
docker-compose down

# Ver logs
docker-compose logs postgres

# Reiniciar serviços
docker-compose restart
```

### Entity Framework
```bash
# Criar nova migração
dotnet ef migrations add <NomeMigração> --project ChallengeJr.Infra --startup-project ChallengeJr.Api

# Atualizar banco de dados
dotnet ef database update --project ChallengeJr.Infra --startup-project ChallengeJr.Api

# Remover última migração
dotnet ef migrations remove --project ChallengeJr.Infra --startup-project ChallengeJr.Api
```

### Desenvolvimento
```bash
# Compilar projeto
dotnet build

# Executar testes
dotnet test

# Executar aplicação em modo watch
dotnet watch run --project ChallengeJr.Api
```

## 📊 Acesso à API

Quando a aplicação estiver rodando:
- **API:** http://localhost:5000 ou https://localhost:5001
- **Swagger:** http://localhost:5000/swagger ou https://localhost:5001/swagger

## 🏗️ Arquitetura

Este projeto segue os princípios da **Clean Architecture**:

1. **Domain**: Entidades de negócio e regras fundamentais
2. **Application**: Casos de uso e lógica de aplicação  
3. **Infrastructure**: Implementações externas (banco de dados, APIs)
4. **Presentation**: Interface com o usuário (Controllers, Web API)

## 🤝 Contribuição

1. Fork o projeto
2. Crie uma branch para sua feature (`git checkout -b feature/AmazingFeature`)
3. Commit suas mudanças (`git commit -m 'Add some AmazingFeature'`)
4. Push para a branch (`git push origin feature/AmazingFeature`)
5. Abra um Pull Request