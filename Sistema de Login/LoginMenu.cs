using Senbozaki_Bank.SistemaDeLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senbozaki_Bank.Sistema_de_Login
{
    public static class LoginMenu
    {
        //Campo de Armazenamento do número digitado pelo usuário
        private static string? OptionInput;


        //Lista de opções pré-definidas
        static readonly List<string> NumeroDeOpcoes = new()
        {
            "0",
            "1",
            "2",
            "5",
        };


        public static void MenuLogin()
        {
            OpcaoInicial("1");
            OptionInput = Console.ReadLine();
            Console.Clear();

            //Tratando possível valor null e opção não identificada
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
                { "1"         ,  "Seção: Login"                          },
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
            Console.WriteLine("1 - User");
            Console.WriteLine("2 - Admin");
            Console.WriteLine("5 - Voltar");

            Console.WriteLine("");
            Console.Write("Opção:");
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
                        Console.Clear();
                        Autenticacao.LoginUser();
                    }
                    return;
                case "2":
                    {
                        Autenticacao.LoginAdmin();
                    }
                    return;
                case "5":
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
