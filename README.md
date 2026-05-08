# AuthApi

Microserviço de autenticação desenvolvido com .NET 10 e Minimal APIs, focado em padrões RESTful e infraestrutura como código. O projeto inclui uma interface de linha de comando (CLI) para interação com o serviço.

## Tecnologias e Ferramentas
- **Linguagem:** C# (.NET 10)
- **Framework:** ASP.NET Core Minimal APIs
- **Infraestrutura:** Docker (DevContainers)
- **Banco de Dados:** SQLite
- **Validação:** FluentValidation (Em processo)

## Estrutura do Repositório
- `src/AuthApi`: Backend responsável pela lógica de autenticação e persistência.
- `src/AuthCli`: Cliente console para consumo dos endpoints da API.
- `.devcontainer`: Configuração para ambiente de desenvolvimento padronizado e isolado.

## Configuração de Ambiente
Introduzida a gestão de portas via variáveis de ambiente para garantir compatibilidade entre o host local e ambientes de nuvem (Codespaces).

### Execução Local
Para testar o fluxo completo da aplicação, é necessário iniciar a API e o cliente CLI em terminais separados.

**1. Iniciando o Backend (API):**
1. Abra um terminal e navegue até o diretório: `cd src/AuthApi`
2. Execute o comando: `dotnet run`
3. A API estará escutando internamente em: `http://localhost:5106`

**2. Iniciando a Interface do Usuário (CLI):**
1. Abra um segundo terminal e navegue até o diretório: `cd src/AuthCli`
2. Execute o comando: `dotnet run` (este comando fará o build automático e iniciará o sistema interativo).

### Execução via DevContainer
Ao abrir o repositório no VS Code com Docker Desktop instalado, o ambiente será configurado automaticamente conforme as especificações em `.devcontainer/devcontainer.json`, isolando as dependências do sistema operacional.

## Arquitetura de Endpoints
Definição de rotas baseada em princípios RESTful e pragmatismo de mercado:
- `POST /register`: Registro de novos usuários (Criação de recurso).
- `POST /auth/login`: Processo de autenticação e emissão de credenciais.

## Autor
**Heitor Rangel**,<br>
Desenvolvedor focado em soluções de backend.
