using System;
using System.Collections.Generic;
using System.Text;

namespace POO_C.classes
{
    public class Venda
    {
        public int Numero { get; set; }
        public Cliente Cliente {get;} 
        public decimal ValorCompra {get; set;}
        public string Situacao {get; set;}

        public Venda(int numero, Cliente cliente, decimal valorCompra)
        {
            Numero = numero;
            Cliente =cliente;
            ValorCompra = valorCompra;
            Situacao = "pendente";
        }

        //metodo para pagamento
        public void RealizarPagamento()
        {
            if(Situacao == "pago")
            {
                Console.WriteLine("Aviso: Esta venda já foi paga anteriormente.");
                return;
            }

            //aqui vai ser implementado ainda outras coisas
            Situacao = "pago";
        }
    }
} 