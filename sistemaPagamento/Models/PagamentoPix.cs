namespace sistemaPagamento;

    public class PagamentoPix : FormaPagamento
    {
        public override string Nome => "PIX";

        public override decimal CalcularValorFinal(decimal valor)
        {
            const decimal desconto = 0.05m;
            return valor - (valor * desconto);
        }
    }
