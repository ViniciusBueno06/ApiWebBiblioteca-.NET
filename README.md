# 📚 API Biblioteca

API REST com padrâo MVC e principios SOLID desenvolvida com .NET para gerenciamento de uma biblioteca, permitindo operações de cadastro, consulta, atualização e remoção de dados.

---

## 🚀 Tecnologias utilizadas

* .NET 8
* ASP.NET Core
* Entity Framework Core
* SQL Server

---

## ⚙️ Como rodar o projeto

### ✅ Pré-requisitos

* .NET 8 instalado
* SQL Server (local ou remoto)

---

### 🔐 Configuração das variáveis de ambiente

Este projeto utiliza um arquivo `.env` para armazenar dados sensíveis.

1. Edite o arquivo `.env.example`:

2. Preencha com sua connection string:

```env
ConnectionStrings__DefaultConnection=Server=SEU_SERVIDOR;Database=ApiBiblioteca;Trusted_Connection=True;TrustServerCertificate=True;
```

---

### 🗄️ Rodar as migrations

```bash
dotnet ef database update
```

---

### ▶️ Executar a aplicação

```bash
dotnet run
```

---


## 🧠 Aprendizados

Este projeto foi desenvolvido com foco em aprendizado nos seguintes tópicos:

* Construção de APIs REST
* Boas práticas com Entity Framework
* Organização em camadas
* Configuração segura de credenciais
* Entendimento de principios SOLID
* Injeção de dependência
* Programação assíncrona
* Retornos HTTPs corretos

---
