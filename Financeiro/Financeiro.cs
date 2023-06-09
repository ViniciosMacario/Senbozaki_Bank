using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senbozaki_Bank.Financeiro
{
    public class Financeiro
    {
        private float  Saldo;
        private string Titular;
        private string NumeroDaConta;
        private string NUmeroDaAgencia;

        //Funções Básicas de um Banco
        public static void Transferir()
        {
            Console.Write("Informe o valor:");
            var valorTransferir = Console.ReadLine();

        }
        public static void Depositar()
        {
            Console.WriteLine("Depositar");
        }
        public static void Sacar()
        {
            Console.WriteLine("Sacar");

        }
        public static void Pagar()
        {
            Console.WriteLine("Pagar");

        }

    }
}
