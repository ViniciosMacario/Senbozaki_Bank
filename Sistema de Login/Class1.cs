using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Diagnostics.CodeAnalysis;

namespace Senbozaki_Bank.SistemaDeLogin
{
    public static class Autenticacao
    {
        //State se o usuário está Autenticado ou não.
        public static bool StateAutenticacao = false;

        //State do nível de acesso do usuário, nível 0 = comum, 1 = admin.
        public static int LevelAutenticao   = 0;

        static readonly Dictionary<LoginUser, string> contasCadastradasLoginUserDicionary = new()
        {
            { new LoginUser("151", "1598", "123"), "Vinicios" }
        };


        //Capturando valores e retornando um Objeto contendo os mesmos.
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
        
        //Login do Usuário Comum
        public static void LoginUser()
        {
            var user = LoginUserMenu();
            //contasCadastradasLoginuser.Contains(user)
            if (contasCadastradasLoginUserDicionary.ContainsKey(user))
            {
                StateAutenticacao = true;
                Console.WriteLine($"Usuário {contasCadastradasLoginUserDicionary[user]} validado!");
            }
            else
            {
                Console.WriteLine("Senha invalida!");
            }
        }
        public static void LoginAdmin()
        {


        }        
    }

    public class LoginUser : IEquatable<LoginUser>
    {
        public string NumeroAgencia  { get; }
        public string NumeroConta    { get; }
        public string Senha          { get; }

        //Criando objeto do Tipo LoginUser
        public LoginUser(string nAgencia, string nConta, string senha)
        {
            NumeroConta = nConta;
            NumeroAgencia = nAgencia;
            Senha = senha;
        }

        //Comparador Personalizado 
        public bool Equals(LoginUser? obj)
        {
            if (obj == null) return false;

            //Se os valores dessas propriedades forem iguais em ambos os objetos, eles serão considerados iguais.
            if (NumeroAgencia == obj.NumeroAgencia && NumeroConta == obj.NumeroConta && Senha == obj.Senha) return true;

            return false;
        }

        public override bool Equals(object? obj) => obj switch
        {
            null => false,
            LoginUser user => Equals(user),
            _ => base.Equals(obj)
        };
        public override int GetHashCode()
        {
            // hash é um algoritmo que mapeia dados de tamanho variável para um valor de tamanho fixo, geralmente um valor numérico ou uma sequência de bytes.
            //A palavra-chave unchecked indica que o cálculo do código hash não levanta uma exceção se ocorrer um estouro de inteiro.
            return HashCode.Combine(NumeroAgencia, NumeroConta, Senha);
        }
    }
}