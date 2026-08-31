using System;
using System.Collections.Generic;
using System.Text;

namespace sistemaPagamento
{
   public enum SituacaoVenda
    {
        Pendente,
        Pago
    }

    public class Venda
    {
        public int Numero { get; }
        public Cliente Cliente { get; }
        public decimal ValorCompra { get; private set; }
        public SituacaoVenda Situacao { get; private set; }

        public FormaPagamento? FormaPagamentoUtilizada { get; private set; }
        public decimal? ValorFinal { get; private set; }

        public Venda(int numero, Cliente cliente, decimal valorCompra)
        {
            if (valorCompra <= 0)
                throw new ArgumentException("O valor da venda deve ser maior que zero.");

            Numero = numero;
            Cliente = cliente;
            ValorCompra = valorCompra;
            Situacao = SituacaoVenda.Pendente;
        }

        // Único ponto de entrada para alterar a situação/valor final da venda
        public void Pagar(FormaPagamento formaPagamento)
        {
            if (Situacao == SituacaoVenda.Pago)
                throw new InvalidOperationException("Esta venda já foi paga.");

            // Polimorfismo: não importa qual subclasse é, o cálculo é chamado da mesma forma
            ValorFinal = formaPagamento.CalcularValorFinal(ValorCompra);
            FormaPagamentoUtilizada = formaPagamento;
            Situacao = SituacaoVenda.Pago;
        }
    }
}
