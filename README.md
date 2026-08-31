# Sistema de Pagamento

Aplicação Console em C# para controle de vendas e pagamentos de uma pequena loja, desenvolvida como exercício de Orientação a Objetos (Encapsulamento, Herança, Abstração e Polimorfismo).

## Funcionalidades

- Cadastrar vendas (número, cliente, CPF, valor)
- Listar vendas cadastradas, com forma de pagamento e valor final quando já pagas
- Realizar pagamento de uma venda via PIX, Cartão de Crédito ou Dinheiro

## Regras de pagamento

| Forma de pagamento | Regra                  |
|---------------------|-------------------------|
| PIX                  | 5% de desconto          |
| Cartão de crédito    | 3% de acréscimo (taxa)  |
| Dinheiro             | Sem desconto ou acréscimo |

## Estrutura do projeto

```
sistemaPagamento/
├── bin/
├── Models/
│   ├── Cliente.cs
│   ├── FormaPagamento.cs
│   ├── PagamentoCartao.cs
│   ├── PagamentoDinheiro.cs
│   ├── PagamentoPix.cs
│   └── Venda.cs
├── Program.cs
└── sistemaPagamento.csproj
```

## Como executar

Pré-requisito: [.NET SDK 10.0](https://dotnet.microsoft.com/download) instalado.

Git Clone do Repositorio : [Repositorio](https://github.com/Anacarlags/SistemaPagamentoPooCsharp.git)

```bash
cd SistemaVendas
dotnet run
```
