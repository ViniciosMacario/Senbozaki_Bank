using Senbozaki_Bank.Financeiro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senbozaki_Bank.Relatorio
{
    public class RelatorioMenu
    {
        //Campo de Armazenamento do número digitado pelo usuário
        private static string? OptionInput;

        //Lista de opções pré-definidas
        static readonly List<string> NumeroDeOpcoes = new()
        {
            "0",
            "1",
            "2"
        };


        public static void MenuRelatorio()
       {
            OpcaoInicial("1");
            OptionInput = Console.ReadLine();
            Console.Clear();

            while (OptionInput?.Length is 0 || NumeroDeOpcoes.Contains(OptionInput!) is false)
            {
                OpcaoInicial("Erro");
                OptionInput = Console.ReadLine();
                Console.Clear();
            }
            DesignacaoDeFuncao(OptionInput!);
        }
        public static void OpcaoInicial(string typeInformation)
        {
            Dictionary<string, string> Frases = new()
            {
                { "1"         ,  "Seção: Relatórios"                     },
                { "Erro"      ,  "Selecione uma opção Valida!!!"         },
                { "Atenção"   ,  "Preste Atenção no Valor informado!!"   },
            };

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"<| {Frases[typeInformation]} |>");
            Console.WriteLine("");

            Console.ResetColor();
            Console.WriteLine("Digite uma opção : ");

            //Opções de navegação
            Console.WriteLine("");
            Console.WriteLine("0 - Sair");
            Console.WriteLine("1 - Contas Cadastradas");
            Console.WriteLine("5 - Voltar");

            //Recebendo opção escolhida do usuário
            Console.WriteLine("");
            Console.Write("Opção:");
        }
        public static void DesignacaoDeFuncao(string Option)
        {
            switch (Option)
            {
                case "0":
                    {
                        for (int i = 3; i >= 1; i--)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine($"Fechando à aplicação em...{i} segundo(s)");
                        }
                        Console.WriteLine($"Aplicação encerrada!");
                        Environment.Exit(0);
                    }
                    return;
                case "1":
                    {
                        RelatoriosMenu.MenuRelatorio();
                    }
                    return;
                case "2":
                    {
                        for (int i = 3; i >= 1; i--)
                        {
                            Thread.Sleep(1000);
                            Console.WriteLine($"Voltando para Home em...{i} segundo(s)");
                        }
                        Console.Clear();
                        Menu.Menu.GeracaoDeOpcoesMaster();
                    }
                    return;
                default: throw new NotImplementedException($"A opção {Option} não foi IMPLEMENTADA!");
            }
        }
    }
}