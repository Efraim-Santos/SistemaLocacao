# SistemaLocacao

<h2>Sinopse</h2>
 
Sistema de gestão de locações de filmes.

<h2>Tecnologias e padrões arquiteturais</h2>
<ul>
  <li>Projeto desenvolvido utilizando .Net 5 EF 5. </li>
  <li>Foi arquiteturado utilizando conceito do DDD com CQRS e mediator para comunicação entre camadas.</li>
  <li>UnitOfWork.</li>
  <li>Banco de dados utilizado na aplicação foi o MySql.</li>
  <li>Para documentar a Api, foi utilizado o Swagger.</li>
</ul>

<h2>Requisitos</h2>
Para executar o projeto deve clonar o repositório, instalar as dependências e por fim configurar o acesso ao banco Mysql no appsettings, passando os dados do banco, no ConnectionStrings e executar o comando "Update-Database -Context SistemaLocacaoContext" para criar o banco de dados.






