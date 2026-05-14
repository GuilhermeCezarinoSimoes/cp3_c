 Sistema de Registro de Ativos Financeiros

Este projeto é uma Console Application desenvolvida em C# para simular o registro de operações de compra e venda de ativos financeiros no mercado de ações. O sistema permite registrar, listar e calcular o balanço total de operações, tudo armazenado em memória.

 Integrantes do Grupo

  Fabrini Soares - RM: 557813
  Guilherme Cezarino - RM: 557724

 Como Executar

1. Certifique-se de possuir o [.NET SDK](https://dotnet.microsoft.com/download) instalado.
2. Clone este repositório: `git clone <URL_DO_SEU_REPOSITORIO>`
3. Abra o terminal na pasta do projeto e execute o comando: `dotnet run`

Critérios de Avaliação Atendidos

*   **Estruturas de Controle:** Uso de `if/else`, `switch`, `do/while` e `foreach`.
*   **POO:** Implementação de `interface (IOperation)`, `abstract (Operation)`, `herança (BuyOperation, SellOperation)` e `polimorfismo (GetDetails)`.
*   **Geração de IDs:** ID sequencial único gerado via propriedade `static _nextId` na classe base.
*   **Tratamento de Exceções:** Uso de `try/catch` para inputs numéricos e lançamentos personalizados como `ArgumentException` para regras de negócio.
*   **Partial Class:** A classe `Operation` foi dividida em duas partes no código para organização lógica.
*   **Armazenamento em Lista:** Uso contínuo de `List<Operation>` para simular o banco de dados temporário.
*   **Legibilidade:** Código indentado, organizado com comentários de documentação.

Evidências de Teste

*(Adicione abaixo os prints ou gifs demonstrando o sistema em funcionamento)*

*   **Print 1:** Menu Inicial e Registro de uma Compra válida e uma Venda válida.
*   **Print 2:** Teste de Exceção (tentando inserir letras no campo de preço, ou valor negativo).
*   **Print 3:** Tela de Listagem com formatação correta.
*   **Print 4:** Cálculo de valor total com precisão nos decimais.



📸 Roteiro de Evidências de Teste
Print 1: O Tratamento de Exceções (A prova de falhas)

O que fazer: Inicie o programa e escolha "1 - Registrar operação". Quando pedir a quantidade ou o preço, digite uma letra (ex: abc) em vez de um número. Outro teste bom é tentar escolher o tipo de operação 3 (que não existe).

O que o print deve mostrar: A mensagem de erro amigável gerada pelos blocos try/catch que criamos, provando que o programa não "quebra" e atende ao Critério 4.

Print 2: O Registro Perfeito (Caminho Feliz)

O que fazer: Registre uma operação de COMPRA válida (ex: 10 de PETR4 a 2,50) e, em seguida, registre uma operação de VENDA válida (ex: 5 de VALE3 a 3,00).

O que o print deve mostrar: O menu funcionando perfeitamente e a mensagem de sucesso ao registrar os ativos.

Print 3: A Listagem e o Polimorfismo

O que fazer: Escolha a opção "2 - Listar operações" logo após ter feito os registros do Print 2.

O que o print deve mostrar: A lista impressa mostrando as tags COMPRA e VENDA, os IDs sequenciais gerados [001], [002] (provando o Critério 3 com o static), e a formatação do método GetDetails() (provando o Critério 2 de Polimorfismo e Herança).

Print 4: O Valor Total Separado

O que fazer: Escolha a opção "3 - Mostrar valor total".

O que o print deve mostrar: A soma correta calculada em tempo real para as compras e para as vendas. Isso demonstra o uso correto da lista na memória (Critério 6) e das estruturas de repetição percorrendo os objetos (Critério 1).

Depois de capturar as imagens, basta salvá-las em uma pasta assets ou images dentro do seu repositório no GitHub e referenciar o caminho delas no arquivo README.md (por exemplo: ![Teste de Exceção](./images/print1.png)).
