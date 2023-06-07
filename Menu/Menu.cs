using Senbozaki_Bank.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senbozaki_Bank.Menu
{
    //Class responsável por fornecer opções iniciais para o usuário navegar pela aplicação.
    public class Menu
    {
        public static void GeracaoDeOpcoesMaster()
        {
            OpcaoInicial(true);
            var optionInput = (Console.ReadLine());
            Console.Clear();

            //Tratando possível valor null
            while (optionInput?.Length is 0)
            {
                OpcaoInicial(false);
                optionInput = Console.ReadLine();
                Console.Clear();
            }

            DesignacaoDeFuncao(optionInput!);
        }


        //Menu Default
        public static void OpcaoInicial(bool typeInformation)
        {
            //Dependendo do tipo, podemos ter Apresentação de boas vindas ou uma mensagem de erro
            if (typeInformation)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("<------------------------------------->");
                Console.WriteLine("| Seja Bem-vindo(a) ao Senbozaki Bank |");
                Console.WriteLine("<------------------------------------->");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("<---------------------------->");
                Console.WriteLine("| Selecione uma opção Valida!!! |");
                Console.WriteLine("<---------------------------->");
            }

            Console.ResetColor();
            Console.WriteLine("Digite uma opção : ");

            //Opções de navegação
            Console.WriteLine("");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Financeiro");
            Console.WriteLine("2 - Gerar Relatório");
            Console.WriteLine("3 - Help");

            //Recebendo opção escolhida do usuário
            Console.WriteLine("");
            Console.Write("Opção:____");
            Console.CursorLeft -= 4;
        }
        //Baseado na opção digitada, vamos chamar uma determinada função X
        public static void DesignacaoDeFuncao(string Option)
        {
            var OptionInt = int.Parse(Option);
            switch (OptionInt)
            {
                case 0:
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
                case 1:
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
                case 2:
                    { 
                        Console.WriteLine();
                    }
                    return;
                case 3:
                    { 
                        Console.WriteLine();
                    }
                    return;
                default: throw new NotImplementedException($"A opção {OptionInt} não foi IMPLEMENTADA!");
            }
        }
    }
}
