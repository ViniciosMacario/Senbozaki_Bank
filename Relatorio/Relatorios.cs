using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senbozaki_Bank.Relatorio
{
    public class RelatoriosMenu
    {
        public static string? OptionInput;

        //Lista de opções pré-definidas
        static readonly List<string> NumeroDeOpcoes = new()
        {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
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
                { "1"         ,  "Seção: Tipo de Conversão/Exibição"     },
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
            Console.WriteLine("1 - Exibir no Console");
            Console.WriteLine("2 - Converter para CSV");
            Console.WriteLine("3 - Converter para TXT");
            Console.WriteLine("4 - Converter para JSON");
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
                        ExibirDadosConsole();
                        MenuRelatorio();
                    }
                    return;               
                case "2":
                    {
                        Console.Clear();
                        ExibirDadosCSV();
                        MenuRelatorio();
                    }
                    return;                
                case "3":
                    {
                        Console.Clear();
                        ExibirDadosTXT();
                        MenuRelatorio();
                    }
                    return;
                case "4":
                    {
                        Console.Clear();
                        Console.WriteLine("Converter para Json");
                        MenuRelatorio();
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
        public static void ExibirDadosCSV()
        {
            // Caminho e nome do arquivo CSV
            string path = "Contas Cadastradas.csv";

            using (StreamWriter writer = new StreamWriter(path))
            {

                writer.WriteLine("Titular; Agencia; Conta; Saldo;");
                foreach(var linha in Read.ReadData())
                {
                    writer.WriteLine($"{linha.Titular}; {linha.numeroDaAgencia}; {linha.numeroDaConta}; {linha.saldo};");
                }
            }
        }
        public static void ExibirDadosTXT()
        {
            string path = "Contas Cadastradas.txt";

            using(StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine("Titular; Agencia; Conta; Saldo");
                foreach (var linha in Read.ReadData())
                {
                    writer.WriteLine($"{linha.Titular}; {linha.numeroDaAgencia}; {linha.numeroDaConta}; {linha.saldo};");
                }
            }
        }
        public static void ExibirDadosConsole()
        {
            Console.WriteLine("Contas Cadastradas:");

            foreach (var Cliente in Read.ReadData())
            {
                Console.WriteLine("---------------------------------------------------");
                Console.WriteLine($"Titular: {Cliente.Titular}                        ");
                Console.WriteLine($"Numero da Agência: {Cliente.numeroDaAgencia}      ");
                Console.WriteLine($"Numero da Conta: {Cliente.numeroDaConta}          ");
                Console.WriteLine($"Saldo: {Cliente.saldo}                            ");
                Console.WriteLine("---------------------------------------------------");
            }

        }
    }
}

/*
 Console.WriteLine("2 - Converter Relatório para Arquivo de Texto");
 Console.WriteLine("3 - Converter Relatório para Json");
*/