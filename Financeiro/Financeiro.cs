using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senbozaki_Bank.Financeiro
{
    public class Financeiro
    {
        //Lista de opções pré-definidas
        static readonly List<string> NumeroDeOpcoes = new()
        {
            "0",
            "1",
            "2",
            "3",
            "4",
        };

        //Campo de Armazenamento do número digitado pelo usuário
        private static string? OptionInput;

        private float  Saldo;
        private string Titular;
        private string NumeroDaConta;
        private string NUmeroDaAgencia;

        public static void GeracaoDeOpcoesMaster()
        {
            OpcaoInicial(true);
            OptionInput = Console.ReadLine();
            Console.Clear();

            //Tratando possível valor null e opção não identificada
            while (OptionInput?.Length is 0 || NumeroDeOpcoes.Contains(OptionInput!) is false)
            {
                OpcaoInicial(false);
                OptionInput = Console.ReadLine();
                Console.Clear();
            }
            DesignacaoDeFuncao(OptionInput!);
        }

        //Menu Default
        public static void OpcaoInicial(bool typeInformation)
        {
            //Dependendo do tipo, podemos ter Apresentação de boas vindas ou uma mensagem de erro
            if (typeInformation)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<------------------------------------->");
                Console.WriteLine("| Preste Atenção no Valor informado!! |");
                Console.WriteLine("<------------------------------------->");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("<------------------------------->");
                Console.WriteLine("| Selecione uma opção Valida!!! |");
                Console.WriteLine("<------------------------------->");
            }
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
            Console.Write("Opção:");
            //Console.CursorLeft -= 4;
        }
        public static void DesignacaoDeFuncao(string Option)
        {
            switch (Option)
            {
                case "0":
                    {
                        for (int i = 5; i >= 1; i--)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine($"Fechando à aplicação em...{i} segundo(s)");
                        }
                        Console.WriteLine($"Aplicação encerrada com Sucesso!");
                        Environment.Exit(0);
                    }
                    return;
                case "1":
                    {
                        for (int i = 3; i >= 0; i--)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine($"Trocando de Sessao em...{i} segundo(s)");
                        }
                        Console.Clear();

                        Financeiro.Financeiro.OpcaoInicial();
                    }
                    return;
                case "2":
                    {
                        Console.WriteLine();
                    }
                    return;
                case "3":
                    {
                        Console.WriteLine();
                    }
                    return;
                default: throw new NotImplementedException($"A opção {Option} não foi IMPLEMENTADA!");
            }
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

        

        //Baseado na opção digitada, vamos chamar uma determinada função X
    }
}
