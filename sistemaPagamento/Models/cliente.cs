using System;
using System.Collections.Generic;
using System.Text;

namespace POO_C.classes 
{
    public class Cliente
    {
        public string Nome { get; set; }
        private decimal CPF { get; }
        
        public Cliente(string nome, decimal cpf)
        {
            Nome = nome;
            CPF = cpf;
        }
    }
}