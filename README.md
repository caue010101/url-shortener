🔗 URL Shortener API

API REST desenvolvida em .NET 8 para encurtamento de URLs com foco em alta performance e redirecionamento eficiente.

Este projeto foi criado para demonstrar o uso de Dapper em cenários de alta leitura e a implementação de algoritmos de geração de identificadores únicos.
🚀 Tecnologias Utilizadas

    .NET 8 (ASP.NET Core)

    PostgreSQL

    Dapper (Micro-ORM)

    Injeção de Dependência Native

    Swagger/OpenAPI

📌 Funcionalidades

    Encurtamento de URL: Recebe uma URL longa e gera um código único de 8 caracteres.

    Redirecionamento: Ao acessar o endpoint com o código, o usuário é redirecionado (302 Found) para a URL original.

    Persistência: Armazenamento seguro no PostgreSQL utilizando Dapper para consultas otimizadas.

    Thread-Safe: Lógica de geração de códigos preparada para múltiplas requisições simultâneas.

🏗️ Estrutura do Projeto

O projeto utiliza o Repository Pattern para desacoplar a lógica de acesso a dados:

    Controllers → Gerencia os endpoints de POST (criar) e GET (redirecionar).

    Services → Contém a lógica de geração do código alfanumérico.

    Repositories → Interface e implementação das queries SQL via Dapper.

    Models/DTOs → Estruturas de dados para entrada e saída da API.

⚡ Diferenciais Técnicos

    Performance: O uso do Dapper elimina o overhead de ORMs tradicionais, tornando a busca por códigos quase instantânea.

    Lógica de Geração: Implementação de algoritmo para garantir códigos únicos e amigáveis para URLs.

    Async/Await: Todo o fluxo de dados é assíncrono, evitando o bloqueio de threads do servidor.

👨‍💻 Autor

Caue Alves
Desenvolvedor Backend .NET
