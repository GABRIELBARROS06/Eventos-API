
## 📌 Sobre o projeto

O **EventHub API** é um sistema back-end que permite:

- 📅 Cadastro de eventos
- 👤 Cadastro e login de participantes
- 📝 Inscrição em eventos
- 🎓 Geração de certificados
- 🔍 Consulta de dados via API

O projeto foi desenvolvido aplicando conceitos de **Programação Orientada a Objetos (POO)** e boas práticas de APIs REST.

---

## 🧱 Arquitetura

O sistema foi organizado em camadas:

- **Models** → Representação das entidades  
- **Services** → Regras de negócio  
- **Controllers** → Endpoints da API  

---

## 📦 Entidades do sistema

- **Evento** → Informações sobre eventos  
- **Participante** → Usuários do sistema  
- **Inscricao** → Relacionamento entre participante e evento  
- **Certificado** → Comprovação de participação  

---

## ⚙️ Funcionalidades

### 🔹 Eventos
- Criar evento
- Listar eventos
- Buscar por ID
- Atualizar evento
- Excluir evento

### 🔹 Participantes
- Cadastro de usuário
- Login
- Exclusão de participante

### 🔹 Inscrições
- Realizar inscrição
- Listar inscrições
- Cancelar inscrição

### 🔹 Certificados
- Gerar certificado
- Listar certificados
- Buscar por código de validação

---

API desenvolvida em **C# com ASP.NET Core** para gerenciamento de eventos acadêmicos inclusivos na área de tecnologia.


## 🧪 Testes

A API pode ser testada através do Swagger:
http://localhost:xxxx/swagger

## 🚀 Como rodar o projeto

### 1. Clonar o repositório

bash
git clone (https://github.com/GABRIELBARROS06/Eventos-API.git)

### 2. Acessar a pasta
cd EventHub.API

### 3. Executar o projeto
dotnet run

🧠 Tecnologias utilizadas
C#
ASP.NET Core
Swagger
.NET 8

📚 Conceitos aplicados
Programação Orientada a Objetos (POO)
Arquitetura em camadas
APIs REST
Validações de regras de negócio

👨‍💻 Autor

Desenvolvido por Gabriel Barros

🔗 LinkedIn: www.linkedin.com/in/gabriel-de-barros-gomes-067059314

🔗 GitHub: https://github.com/GABRIELBARROS06
