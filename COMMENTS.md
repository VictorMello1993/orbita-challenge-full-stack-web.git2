# Decisão da arquitetura
Observando as funcionalidades do projeto, por se tratar de um CRUD de alunos, foi possível adotar Clean Architeture para separar as classes em diferentes camadas. O projeto foi organizado em quatro camadas:

 - Domain
 - Application
 - Infrastructure
 - API

## Camada de domínio
  Na camada de domínio, foram criadas as classes de entidade de usuários e alunos. Também nessa mesma camada, também conta com uma classe abstrata **BaseEntity** que será alimentada pelas classes de usuário e aluno por id e data de cadastro. Além disso, contém as interfaces para se comunicar com a camada de infraestrutura para acesso ao banco de dados, via injeção de dependência, através do padrão **Repository**. Além de desacoplar as classes de domínio com as de infraestrutura, o motivo que adotei o padrão Repository é para tornar o código mais fácil de utilizar os testes unitários ao longo do desenvolvimento do projeto. 

  Ainda nessa mesma camada, também contém classes para tratamento de exceções que podem ocorrer durante a requisição. Por último, possui serviços com métodos responsáveis por efetuar login no sistema utilizando a autenticação JWT, juntamente com método de encriptar a senha para armazenar de maneira segura no banco de dados. 

## Camada de aplicação
  Na camada de aplicação, é o que representa casos de uso do sistema, ou seja, as funcionalidades que o usuário poderá fazer no sistema, como cadastrar aluno, alterar ou excluir, logar no sistema, redefinir a senha, gerenciar alunos, entre outras. Nessa camada, foi adotado o padrão **CQRS** para separar as responsabilidades de cada funcionalidade do sistema, no sentido de separar as consultas (queries) das ações que alteram o estado do sistema (commands). Isso deixa o código dos controllers mais limpo, sem precisar adotar os serviços da camada de aplicação, que além de misturar os métodos que consultam com os os métodos que alteram o sistema, isso normalmente o deixaria mais extenso.
  
  Além disso, contém as classes de DTO's para representar os input models para representar a entrada de dados da API, e os view models para representar a saída de dados para exibir na API quando completar uma requisição.
  
  Ainda nessa mesma camada, implementei todas as classes de validação para validar a entrada de dados da API.

## Camada de infraestrutura
  Na camada de infraestrutura contém as classes concretas de acesso a dados através do padrão Repository, a classe de mapeamento do Entity Framework (classe DbContext) e as migrations utilizadas para versionar as alterações realizadas no banco de dados a partir do mapeamento do Entity Framework. Também contém as classes concretas de serviços, como no caso, de serviço de autenticação usuário, tudo isso adotando via injeção de dependência da mesma maneira como ocorre nas classes repository.
  
## Camada de API
  Na camada de API contém os controllers e os filtros, sendo que foi implementada um filtro de validação para deixar o código dos controllers ainda mais limpo, sem ter que fazer checagem diretamente por lá.
  
  ```csharp 
  if(!ModelState.IsValid){
    //Retornar BadRequest
  }
  ```
  
# Bibliotecas utilizadas
- Entity Framework Core
- Microsoft.AspNetCore.Authentication.JwtBearer
- Fluent Validation para validação de entrada de dados da API
- Swashbuckle.AspNetCore (documentação da API com Swagger)
- MySql.EntityFrameworkCore
- MediatR (junto com o padrão CQRS) 
- xUnit
- Moq

# Possíveis melhorias
- Criar um middleware para tratamento de exceções da API
- Se eu tivesse conhecimento de front-end com Vue.js, talvez eu implementaria o padrão OAuth no lugar do JWT, (ex: Botão de logar com Google) em vez do usuário ter que criar uma conta escrevendo e-mail e a senha.
- Implementar as requisições de API via cache, para melhorar a performance

# Requisitos obrigatórios não entregues
- Front-end
