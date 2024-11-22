# Sistema de Monitoramento de Usinas Nucleares

## Visão Geral do Projeto
Este projeto é um sistema desenvolvido em ASP.NET Core para o monitoramento de usinas nucleares. 
Ele permite a gestão centralizada de métricas de usinas, sensores, análises e alertas críticos. 
O objetivo principal é fornecer uma plataforma robusta e eficiente para acompanhar o desempenho de 
usinas nucleares e garantir a segurança e eficiência operacionais.

### Pricipais Funcionalidades
- **Gerenciamento de Usinas:** Gerencie informações detalhadas sobre usinas, incluindo capacidade total e número de reatores.
  - **Informações de Sensores e Metricas:** Junto com as usinas obtenha informações de sensores (associados a cada usina e acompanhe seu status e localização) e metricas obtendo informações gerais em relação as geração de energia da usina.
- **Alertas de Segurança:** Geração de alertas baseados em critérios predefinidos, com funcionalidades para resolução e acompanhamento.
- **Integração com Banco de Dados Oracle:** Uso de procedures para operações otimizadas e validações de dados.

## Funcionalidades
### CRUD Completo
- **CREATE:** Inserção de todas as tabelas feita pelo Banco de Dados
- **Usinas Nucleares:**
  - **READ:** Visualização de usinas.
  - **READ:** Visualização detalha de dados da usina.
- **Alertas:**
  - **CREATE:** Geração de alertas por meio dos dados obtidos pelas análises.
  - **UPDATE:** Resolução dos alertas.
  - **DELETE:** Exclusão do alerta após a resolução.

### Monitoramento Prático
- Exibição consolidada de métricas de usinas e sensores em uma interface amigável.
- Destaque para alertas críticos e informações relevantes.

### Validações Robustas
- Todas as inserções e atualizações passam por validações de dados diretamente no banco de dados usando funções PL/SQL.

## Estrutura do Projeto
O projeto segue uma arquitetura em camadas para facilitar a manutenção e escalabilidade:

- Camada de Apresentação (Controllers e Views):
  - Responsável por renderizar as páginas HTML e processar interações do usuário.
- Camada de Aplicação (Services):
  - Lógica de negócios e comunicação entre controllers e repositórios.
- Camada de Persistência (Repositories):
  - Acesso ao banco de dados e execução de queries e procedures.
- Camada de Modelos (Models):
  - Representação das entidades do banco de dados e DTOs para transferência de dados.

## Pré-requisitos
- .NET SDK (versão 6 ou superior)
- Visual Studio ou Visual Studio Code
- Banco de Dados Oracle com as procedures configuradas:
  - Link do Repositório com as procedure: ([https://github.com/VitorOnofreRamos/BancoDeDadosGlobal](https://github.com/VitorOnofreRamos/BancoDeDadosGlobal))
- Ferramentas Oracle:
  - Oracle SQL Developer para gerenciamento do banco de dados

## Instruções de Instalação
### 1. Clonar o Repositórios
- Para `Global-Solution-ADB`
```bash
git clone https://github.com/VitorOnofreRamos/Global-Solution-ADB.git
cd Global-Solution-ADB
```
- Para `BancoDeDadosGlobal`
```bash
```
### 2. Configuração do Banco de Dados
- Certifique-se de que o banco de dados Oracle está configurado e com as procedures PL/SQL incluídas.
- Atualize a string de conexão no arquivo `appsettings.json` com as credenciais corretas:
```json
"ConnectionStrings": {
  "FiapOracleConnection": "User Id=seu_usuario;Password=sua_senha;Data Source=seu_servidor"
}
```
### 3. Configuração da Migrations
- Se você precisar criar uma nova migration para refletir mudanças no modelo do banco de dados, execute o seguinte comando.
  - Abra o **PowerShell** no diretório do seu projeto.
  - Execute o comando abaixo para criar a migration:
       
  ```bash
  dotnet ef migrations add NomeDaMigration
  ```
  *Ou se você etiver executando os comados pela IDE do Visual Studio:*
  ```bash
  Add-Migration NomeDaMigration
  ```
  *Substitua `NomeDaMigration` por um nome descritivo, como por exemplo `AddAppointmentsTable`.*
     
- Rode as migrações do Entity Framework para criar as tabelas necessárias:
  ```bash
  dotnet ef database update
  ```
  *Ou*
  ```bash
  Update-Database
  ```

### 4. Configuração do Projeto:
- Abra o projeto em seu editor de preferência (recomendado: Visual Studio ou Visual Studio Code).
- Restaure as dependências:
```bash
dotnet restore
```

### 5. Iniciar a Aplicação:
```bash
dotnet run
```
- Acesse a aplicação em `http://localhost:8080` (ou conforme a configuração do seu ambiente).

## Rotas Principais
- `/` - Página inicial com a lista de consultas agendadas.
### Usinas Nucleares
- `/NuclearPlant`: listagem de usinas.
- `/NuclearPlant/Details/{id}`: Visualização de informações detalhadas de uma usina.
- `/NuclearPlant/ToJson/{id}`: Visualização de informações de uma usina em JSON.

### Alertas
- `/Alerta`: Listagem de alertas
- `/Alerta/Details;{id}`: Visualização de informações detalhadas de uma alerta.
- `/Alerta/ToJson/{id}`: Visualização de informações de uma usina em JSON.
- `/Alert/Resolve/{id}`: Resolução de um alerta específico.
- `/Alert/Delete/{id}`: Exclusão de um alerta *(só pode ser feito caso o alerta já esteje resolvido)*.

## Layout e Customização
- **Interface Responsiva**: Desenvolvida com **Bootstrap**, garantindo visualização otimizada em diferentes dispositivos.
- **Navegação Intuitiva:**
  - Barra de navegação fixa para acesso rápido às principais páginas.
  - Botões claros para ações como criação, edição e exclusão de registros.
 
## Integrantes
### Turma 2TSDSPS
- **Vitor Onofre Ramos** | RM553241
- **Pedro Henrique** | RM553801
- **Beatriz Silva** | RM552600
