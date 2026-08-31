using System;
using System.Collections.Generic;
using System.Text;

namespace sistemaPagamento
{
    public abstract class FormaPagamento
    {
        public abstract string Nome { get; }

        // Cada subclasse decide sua propria regra de calculo
        public abstract decimal CalcularValorFinal(decimal valor);
    }
}