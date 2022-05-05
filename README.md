# Simulador de caixa eletônico CASH_MACHINE

Projeto simulador de uma api para caixas eletrônicos

### Tecnologias utilizadas
 
- .NET 5.0
- ASP.NET Core
- EF Core 5.0
- MySql 8.0
- Xunit

## Configurações iniciais

### Comandos

- dotnet restore
- dotnet test
- dotnet ef database update --project .\1.Host\DesafioTDD.api\DesafioTDD.api.csproj
- dotnet watch run --project .\1.Host\DesafioTDD.api\DesafioTDD.api.csproj

### Divisão dos testes unitários

Os Testes foram aplicados apenas na camada *Application* e têm com objetivo garantir as funcionalidades das regras de negôcio da aplicação. 
Por esse motivo eles não foram aplicados nos fluxos de verificação de nulidade.

Através da flag *--filter* é possível categorizar os testes em:

- *Namespace*
- *Class*
- *Method*

### Dados para verificação

Foram inseridos dados para facilitar a verificação do funcionamento:

- Caixa eletrônico com id = 1 tem R$ 100 sendo uma nota de 50, duas de 20, e uma de 10;
- Cliente com id = 1 tem R$ 100 de saldo disponível;
- Ambos tem o banco com Id = 1. 

## Funcionalidades

### Permissões

Gerentes podem:

- Realizar o CRUD de bancos;
- Realizar o CRUD, inserir e retirar dinheiro de caixas eletrônicos;

Clientes podem:

- Alterar seu nome e senha;
- Consultar seu saldo;
- Consultar seus extratos;
- Sacar ou depositar valores;
- Encerrar sua conta.

### Validações

BANCO:

- Bancos possuem nome e prefixos de cartão;
- Prefixos de cartão deve conter uma lista separada por "-" para cada prefixo
Ex. 1234-5678 Nesse caso temos dois prefixos válidos "1234" e "5678" mas podemos ter inúmeros;

- Prefixos devem ser únicos.
Ex.  Se cadastrarmos o banco A com "1234-5678" o banco B não pode cadastrar "5678";

- Não deve-se deletar bancos que possuam caixas eletrônicos cadastrados;
- Não deve-se deletar bancos que possuam clientes cadastrados.

CAIXA ELETRÔNICO:

- Cada caixa eletrônico possuí um único banco;
- Não deve-se deletar caixas eletrônicos que possuam dinheiro;

CLIENTE:

- Cada cliente possuí apenas um banco e um cartão;
- O número do cartão é gerado ao criar uma conta e tem como prefixo; 
- Não deve-se deletar cliente com saldo em conta.

OPERAÇÕES:

- Clientes só podem depositar e sacar em caixas eletrônicos do mesmo banco que o seu;
- Para o saque, é necessário que o cliente tenha o saldo e o caixa eletrônico a quantia disponível;
- Os depósitos são realizados através da inserção das quantidades de cada cédula;
- O Saque sempre retornará notas de maior valor disponível.
EX. Cliente efetua um saque de R$ 100 e o caixa não tem cédulas de cem, ele irá retornar com as notas menores disponíveis;

- Caso o valor do saque contenha casas decimais, o saque efetivo sera de um valor inteiro mais próximo disponível
EX. valor do saque: R$ 999.99, o saque efetivo será de R$ 999. 

## Considerações

O projeto proporcionou o avanço dos conhecimentos na tecnologia ASP.NET e no método TDD.
