﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senbozaki_Bank.SistemaDeLogin
{
    public static class Autenticacao
    {
        static List<LoginUser> contasCadastradasLoginuser = new()
        {
            new LoginUser("1515", "1598", "123")
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
            if(contasCadastradasLoginuser.Contains(user))
            {
                Console.WriteLine("Usuário validado!");
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
        public string NConta { get; }
        public string NAgencia { get; }
        public string Senha { get; set; }

        public LoginUser(string nConta, string nAgencia, string senha)
        {
            Senha = senha;
            NConta = nConta;
            NAgencia = nAgencia;
        }

        public bool Equals(LoginUser? obj)
        {
            if (obj == null) return false;

            if(NAgencia == obj.NAgencia && NConta == obj.NConta && Senha == obj.Senha) return true;
            
            return false;
        }

        public override bool Equals(object? obj) => obj switch
        {
            null => false,
            LoginUser user => Equals(user),
            _ => base.Equals(obj)
        };
        public override int GetHashCode() => base.GetHashCode();
    }
}