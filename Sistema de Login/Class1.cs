using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senbozaki_Bank.SistemaDeLogin
{
    public static class Autenticacao
    {
        


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
            var senha = Console.ReadLine();

            Console.WriteLine("<----------------------------->");

            return new LoginUser(numeroDaAgencia!, numeroDaConta!, senha!);

        }
        //Login do Usuário Comum
        public static void LoginUser()
        {
            var user = LoginUserMenu();
            Console.WriteLine(user.NAgencia);
            Console.WriteLine(user.NConta);
            Console.WriteLine(user.Senha);

        }
        public static void LoginAdmin()
        {


        }        


    }

    public class LoginUser
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




    }
}