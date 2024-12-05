# Projeto Zoo

Este projeto é um sistema CRUD (Create, Read, Update, Delete) desenvolvido em .NET para gerenciar um zoológico. O projeto utiliza **ADO.NET** para interação com o banco de dados **MS SQL Server**.

## Tecnologias Utilizadas

- **.NET**
- **ADO.NET**
- **MS SQL Server**

## Funcionalidades

- **Adicionar Animais**: Permite adicionar novos animais ao zoológico.
- **Visualizar Animais**: Exibe uma lista de todos os animais cadastrados.
- **Atualizar Informações**: Permite editar as informações dos animais já cadastrados.
- **Remover Animais**: Permite a remoção de animais do zoológico.

## Estrutura do Projeto

- **DataBase**: Contém os scripts SQL para criação e manipulação do banco de dados.
- **Zoo**: Contém o código-fonte do projeto em C#.

## Como Executar

Siga os passos abaixo para configurar e executar o projeto:

### 1. Clone o Repositório

Abra o terminal ou prompt de comando e execute o comando:

```bash
git clone https://github.com/NVanitas/Projeto-Zoo.git
cd Projeto-Zoo
```

### 2. Configuração do Banco de Dados

#### a. Criar o Banco de Dados

1. Abra o **SQL Server Management Studio** (SSMS).
2. Crie um novo banco de dados no MS SQL Server.

#### b. Atualizar as Strings de Conexão

Abra os arquivos **`program.cs`** e **`Login.cs`** no projeto e atualize as strings de conexão para apontar para o seu servidor de banco de dados. 

Exemplo de configuração da string de conexão:

```csharp
"Server=SEU_SERVIDOR;Database=SEU_BANCO_DE_DADOS;User Id=SEU_USUARIO;Password=SUA_SENHA;"
```

### 3. Executar o Projeto

1. Abra o projeto no **Visual Studio**.
2. Compile e execute o projeto.
3. Utilize as credenciais abaixo para fazer login no sistema:

   - **Usuário**: `usuario`
   - **Senha**: `senha`

### 4. Funcionalidades do Sistema

- **Adicionar Animais**: Ao acessar a funcionalidade de adicionar, você poderá inserir novos animais no zoológico.
- **Visualizar Animais**: Uma lista completa de todos os animais cadastrados será exibida.
- **Atualizar Animais**: Se precisar modificar as informações de algum animal, você pode acessar a opção de atualização.
- **Remover Animais**: Para remover um animal do zoológico, basta acessar a funcionalidade de remoção.

## Contribuindo para o Projeto

Contribuições são bem-vindas! Para contribuir:

1. Faça um **fork** do repositório.
2. Crie uma **branch** para suas alterações (`git checkout -b feature/nome-da-sua-feature`).
3. Faça as alterações desejadas e **commit** as mudanças.
4. Envie um **pull request** com uma descrição detalhada da sua contribuição.

## Licença

Este projeto está licenciado sob a [MIT License](LICENSE).
