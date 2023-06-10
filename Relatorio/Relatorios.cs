using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senbozaki_Bank.Relatorio
{
    public class RelatoriosMenu
    {        
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
                        ExibirContasCadastradas();
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
        public static void ExibirContasCadastradas()
        {
            Console.WriteLine("Contas Cadastras:");
            
            foreach(var Cliente in Read.ReadData())
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
 Console.WriteLine("1 - Converter Relatório para Arquivo Excel");
 Console.WriteLine("2 - Converter Relatório para Arquivo de Texto");
 Console.WriteLine("3 - Converter Relatório para Json");
*/