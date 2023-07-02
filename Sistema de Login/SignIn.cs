using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Senbozaki_Bank.Sistema_de_Login.TypesUsers;

namespace Senbozaki_Bank.Sistema_de_Login
{
    public static class SignIn
    {
        /*
         State se o usuário está Autenticado ou não.
        */
        public static bool StateAutenticacao = false;

        /*
         State do nível de acesso do usuário, nível 0 = comum, 1 = admin.
        */
        public static int LevelAutenticao = 0;

        /*
            Campo de Armazenamento do número digitado pelo usuário 
        */
        private static string? OptionInput;

        /*
         Lista de opções pré-definidas 
        */
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
                        LoginUser();
                    }
                    return;
                case "2":
                    {
                        LoginAdmin();
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


        /* 
         Capturando valores e retornando um Objeto contendo os mesmos.
        */
        public static LoginUser LoginUserMenu()
        {

            Console.WriteLine("<----------------------------->");

            Console.Write("Nº Conta:");
            var numeroDaAgencia = Console.ReadLine();

            Console.WriteLine("<----------------------------->");

            Console.Write("Nº Agência:");
            var numeroDaConta = Console.ReadLine();

            Console.WriteLine("<----------------------------->");
            Console.Write("Senha:");


            ConsoleKeyInfo TeclaDigitada;
            string senha = "";

            //O bloco de código dentro do "do" é executado primeiro, e depois é verificada uma condição no while. Se a condição for verdadeira, o loop continua e o bloco de código é executado novamente. Se a condição for falsa, o loop é encerrado e a execução continua com o código após o bloco do-while.
            do
            {
                //Console.ReadKey(true) - Com o argumento true: Esse formato aguarda a pressionar da tecla, mas não exibe a tecla pressionada no console. É útil para capturar informações confidenciais, como senhas, sem exibi-las visualmente.
                TeclaDigitada = Console.ReadKey(true);

                if (TeclaDigitada.Key != ConsoleKey.Enter)
                {
                    //A propriedade KeyChar do objeto ConsoleKeyInfo representa o caractere associado à tecla pressionada pelo usuário. 
                    senha += TeclaDigitada.KeyChar;
                }

                //Enquanto o usuário não apertar a tecla Enter, continue executando.
            } while (TeclaDigitada.Key != ConsoleKey.Enter);

            Console.WriteLine(string.Empty);
            Console.WriteLine("<----------------------------->");

            return new LoginUser(numeroDaAgencia!, numeroDaConta!, senha!);
        }
        /*
         Capturando valores e retornando um Objeto contendo os mesmos.
        */
        public static LoginAdmin LoginAdminMenu()
        {

            Console.WriteLine("<----------------------------->");

            Console.Write("Nome:");
            var nome = Console.ReadLine();

            Console.WriteLine("<----------------------------->");
            Console.Write("Senha:");

            ConsoleKeyInfo TeclaDigitada;
            string senha = "";

            do
            {
                TeclaDigitada = Console.ReadKey(true);

                if (TeclaDigitada.Key != ConsoleKey.Enter)
                {
                    senha += TeclaDigitada.KeyChar;
                }

            } while (TeclaDigitada.Key != ConsoleKey.Enter);

            Console.WriteLine(string.Empty);
            Console.WriteLine("<----------------------------->");

            return new LoginAdmin(nome!, senha!);
        }


        //Login do Usuário Comum
        public static void LoginUser()
        {
            var user = LoginUserMenu();
            //contasCadastradasLoginuser.Contains(user)
            if (contasCadastradasLoginUserDicionary.ContainsKey(user))
            {
                StateAutenticacao = true;
                Console.WriteLine($"Usuário {contasCadastradasLoginUserDicionary[user]} validado!");
                Menu.Menu.GeracaoDeOpcoesMaster();
            }
            else
            {
                Console.WriteLine("Senha invalida!");
            }
        }

        //Login do Usuário Admin
        public static void LoginAdmin()
        {
            var user = LoginAdminMenu();

            //contasCadastradasLoginuser.Contains(user)
            if (contasCadastradasLoginAdminDicionary.ContainsKey(user))
            {
                StateAutenticacao = true;
                Console.WriteLine($"Admin {contasCadastradasLoginAdminDicionary[user]} validado!");
                Menu.Menu.GeracaoDeOpcoesMaster();

            }
            else
            {
                Console.WriteLine("Senha invalida!");
            }
        }
    }
}