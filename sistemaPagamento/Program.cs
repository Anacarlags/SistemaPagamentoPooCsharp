using System;
using System.Collections.Generic;
using System.Globalization;

namespace sistemaPagamento
{
    class Program
    {
        static List<Venda> vendas = new List<Venda>();
        static CultureInfo cultura = new CultureInfo("pt-BR");

        static void Main(string[] args)
        {
            int opcao;
            do
            {
                Console.WriteLine("================================");
                Console.WriteLine("SISTEMA DE VENDAS");
                Console.WriteLine("================================");
                Console.WriteLine("1 - Cadastrar venda");
                Console.WriteLine("2 - Listar vendas");
                Console.WriteLine("3 - Realizar pagamento");
                Console.WriteLine("0 - Sair");
                Console.WriteLine("================================");
                Console.Write("Escolha uma opção: ");
                opcao = LerInt();

                switch (opcao)
                {
                    case 1: CadastrarVenda(); break;
                    case 2: ListarVendas(); break;
                    case 3: RealizarPagamento(); break;
                    case 0: Console.WriteLine("Saindo..."); break;
                    default: Console.WriteLine("Opção inválida."); break;
                }

                Console.WriteLine();
            } while (opcao != 0);
        }

        static void CadastrarVenda()
        {
            try
            {
                Console.Write("Número: ");
                int numero = LerInt();

                Console.Write("Cliente: ");
                string nome = Console.ReadLine() ?? "";

                Console.Write("CPF: ");
                string cpf = Console.ReadLine() ?? "";

                Console.Write("Valor: ");
                decimal valor = LerDecimal();

                var cliente = new Cliente(nome, cpf);
                var venda = new Venda(numero, cliente, valor);

                vendas.Add(venda);

                Console.WriteLine();
                Console.WriteLine("Venda cadastrada com sucesso!");
                Console.WriteLine($"Situação: {venda.Situacao}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao cadastrar venda: {ex.Message}");
            }
        }

        static void ListarVendas()
        {
            if (vendas.Count == 0)
            {
                Console.WriteLine("Nenhuma venda cadastrada.");
                return;
            }

            foreach (var venda in vendas)
            {
                Console.WriteLine();
                Console.WriteLine($"Venda: {venda.Numero}");
                Console.WriteLine($"Cliente: {venda.Cliente.Nome}");
                Console.WriteLine($"Valor original: {venda.ValorCompra.ToString("C", cultura)}");
                Console.WriteLine($"Situação: {venda.Situacao}");

                if (venda.Situacao == SituacaoVenda.Pago && venda.FormaPagamentoUtilizada != null)
                {
                    Console.WriteLine($"Forma de pagamento: {venda.FormaPagamentoUtilizada.Nome}");
                    Console.WriteLine($"Valor final: {venda.ValorFinal!.Value.ToString("C", cultura)}");
                }
            }
        }

        static void RealizarPagamento()
        {
            Console.Write("Número da venda: ");
            int numero = LerInt();

            var venda = vendas.Find(v => v.Numero == numero);
            if (venda == null)
            {
                Console.WriteLine("Venda não encontrada.");
                return;
            }

            if (venda.Situacao == SituacaoVenda.Pago)
            {
                Console.WriteLine("Esta venda já foi paga.");
                return;
            }

            Console.WriteLine("Escolha a forma de pagamento:");
            Console.WriteLine("1 - PIX");
            Console.WriteLine("2 - Cartão de crédito");
            Console.WriteLine("3 - Dinheiro");
            Console.Write("Opção: ");
            int opcaoPagamento = LerInt();

            // Aqui está o polimorfismo: a variável é do tipo abstrato FormaPagamento
            FormaPagamento? formaPagamento = opcaoPagamento switch
            {
                1 => new PagamentoPix(),
                2 => new PagamentoCartao(),
                3 => new PagamentoDinheiro(),
                _ => null
            };

            if (formaPagamento == null)
            {
                Console.WriteLine("Forma de pagamento inválida.");
                return;
            }

            try
            {
                decimal valorOriginal = venda.ValorCompra;

                // O mesmo código funciona para qualquer forma de pagamento
                venda.Pagar(formaPagamento);

                Console.WriteLine();
                Console.WriteLine($"Valor original: {valorOriginal.ToString("C", cultura)}");
                Console.WriteLine($"Forma de pagamento: {formaPagamento.Nome}");
                Console.WriteLine($"Valor final: {venda.ValorFinal!.Value.ToString("C", cultura)}");
                Console.WriteLine("Pagamento realizado com sucesso.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao realizar pagamento: {ex.Message}");
            }
        }

        static int LerInt()
        {
            int valor;
            while (!int.TryParse(Console.ReadLine(), out valor))
                Console.Write("Valor inválido, digite novamente: ");
            return valor;
        }

        static decimal LerDecimal()
        {
            decimal valor;
            while (!decimal.TryParse(Console.ReadLine(), NumberStyles.Any, cultura, out valor))
                Console.Write("Valor inválido, digite novamente: ");
            return valor;
        }
    }
}
