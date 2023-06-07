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

        public static void OpcaoInicial()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("<---------------------->");
            Console.WriteLine("| Seção(1): Financeiro |");
            Console.WriteLine("<---------------------->");
            
            Console.ResetColor();
            Console.WriteLine("Digite uma opção : ");

            //Opções de navegação
            Console.WriteLine("");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Transferir");
            Console.WriteLine("2 - Depositar");
            Console.WriteLine("3 - Sacar");
            Console.WriteLine("4 - Pagar");
            Console.WriteLine("5 - Voltar");

            //Recebendo opção escolhida do usuário
            Console.WriteLine("");
            Console.Write("Opção:____");
            Console.CursorLeft -= 4;
        }


        //Funções Básicas de um Banco
        public void Transferir()
        {
            Console.Write("Informe o valor:");
            var valorTransferir = Console.ReadLine();

        }
        public void Depositar()
        {

        }
        public void Sacar()
        {

        }
        public void Pagar()
        {

        }
    }
}
