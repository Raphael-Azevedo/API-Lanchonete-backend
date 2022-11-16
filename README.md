# Exame Prático .NET
Neste repositório encontra-se a resolução do Exame Prático para a vaga de backend Junior.

## Projeto Lanche Bom
****
## Funcionalidades

Api onde é possível ver a lista de itens cadastrados na aplicação e criação, atualização e deleção de pedidos.

### Endpoints

- GET: /api/ItemPedido - Lista todos os itens tanto lanches quantos adicionais;
- GET: /api/ItemPedido/GetLanches - Lista apenas os Lanches;
- GET: /api/ItemPedido/GetAdicionais - Lista apenas os adicionais;

- GET: /api/Pedido - Lista todos os pedidos;
- POST: /api/Pedido - Cria um pedido e retorna o valor que será cobrado;
- PUT: /api/Pedido{id} - Atualiza um pedido;
- DELETE: /api/Pedido{id} - Deleta um pedido;
****
## Tecnologias utilizadas
- `Entitiy Framework`
- `.NET 6`
- `SQL Lite`

## Banco de dados

Para a criação do sistema foi definido um relacionamento muitos para muitos.

Banco de dados utilizado no projeto é o SQL LITE;

Projeto já com banco criado e na aplicação, decidido usar o SQL LITE pela facilidade de visualização de dados que trás junto com sua funcionalidade de ser um banco local.

## Características do projeto

Usado padrão UnitOfWork e padrão Repository como forma de demonstrar conhecimento em padrões de projetos.

Utilizado data annotations e DTO.

Utilizado Fluent Api.

Banco de dados preenchido pela própria aplicação para adicionar os itens do pedido.
