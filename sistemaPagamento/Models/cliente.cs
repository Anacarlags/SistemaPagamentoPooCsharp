using System;
using System.Collections.Generic;
using System.Text;

namespace sistemaPagamento{
   public class Cliente
    {
        public string Nome { get; private set; }
        public string Cpf { get; }

        public Cliente(string nome, string cpf)
        {
            Nome = nome;
            Cpf = cpf; // definido apenas no construtor, nunca mais alterado
        }
    }
}