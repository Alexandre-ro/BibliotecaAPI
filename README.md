# 📚 BibliotecaAPI

[![.NET Version](https://img.shields.io/badge/.NET-8.0-blue.svg)](https://dotnet.microsoft.com/)
[![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core%208.0-green.svg)](https://docs.microsoft.com/en-us/ef/)
[![License](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)

Bem-vindo à **BibliotecaAPI**, uma aplicação construída para gerenciar o cadastro de livros e autores de uma biblioteca.  
O projeto foi desenvolvido em **.NET 8** utilizando o **Entity Framework Core** para manipulação de dados.

---

## 🛠️ Funcionalidades

- 📖 **Cadastro de Livros**: Adicione, edite, remova e visualize livros.
- ✍️ **Cadastro de Autores**: Gerencie informações dos autores associados aos livros.
- 🔍 **Busca Avançada**: Pesquise livros por título ou autor.
- 🗂️ **Relacionamento Autor-Livro**: Vincule autores a um único livro e vice-versa.

---

## 🏗️ Tecnologias Utilizadas

- **.NET 8**
- **Entity Framework Core**
- **SQL Server** como banco de dados
- **Swagger** para documentação interativa da API
---

## 🚀 Instalação e Execução

Siga os passos abaixo para configurar o projeto localmente:

### Pré-requisitos
- [.NET SDK 8.0](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [SQL Server](https://www.microsoft.com/pt-br/sql-server/sql-server-downloads)

### Clonando o repositório

```bash
git clone https://github.com/Alexandre-ro/BibliotecaAPI.git
cd BibliotecaAPI

Atualize a string de conexão no arquivo appsettings.json:
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=LibraryDB;User Id=seu_usuario;Password=sua_senha;"
}

Execute as migrações para criar o banco de dados:
dotnet ef database update

Inicie o servidor:
dotnet run

Acesse a documentação da API via Swagger 

