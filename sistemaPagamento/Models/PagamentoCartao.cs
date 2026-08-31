 using System;
using System.Collections.Generic;
using System.Text;

namespace sistemaPagamento{
 public class PagamentoCartao : FormaPagamento
    {
        public override string Nome => "Cartão de crédito";

        public override decimal CalcularValorFinal(decimal valor)
        {
            const decimal taxa = 0.03m;
            return valor + (valor * taxa);
        }
    }
} 