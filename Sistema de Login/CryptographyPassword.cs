using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Intrinsics.Arm;
using System.Runtime.Intrinsics.X86;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Senbozaki_Bank.Sistema_de_Login
{
    public static class Cryptography
    {

        /* 
         * é responsável por gerar um salt aleatório e exclusivo para cada usuário. O salt é uma sequência de bytes aleatórios que é adicionada à senha antes de calcular o hash, aumentando a complexidade da senha armazenada no banco de dados e dificultando ataques de dicionário ou ataques de força bruta.
        */
        public static string CreateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                /* 
                  chamamos o método GetBytes() do objeto RandomNumberGenerator e passamos o array saltBytes como parâmetro. Esse método preenche o array saltBytes com valores aleatórios seguros. 
                */
                rng.GetBytes(saltBytes);
            }

            /*
              Agora você tem uma string que representa o salt gerado aleatoriamente e exclusivo para um usuário específico. É importante armazenar esse salt junto com o hash da senha no banco de dados, pois ele será necessário para verificar a autenticidade da senha durante o processo de login. 
            */
            return Convert.ToBase64String(saltBytes); 
        }

        public static string CryptographyPassword(string senha)
        {
            /*
            SHA512:é um algoritmo criptográfico amplamente utilizado para calcular o hash de dados.
            */
            using (var sha512 = SHA512.Create())
            {
                byte[] passwordByte = Encoding.UTF8.GetBytes(senha);
                byte[] saltByte = Convert.FromBase64String(CreateSalt());

                byte[] passwordWithSaltBytes = new byte[passwordByte.Length + saltByte.Length];
                Array.Copy(passwordByte, passwordWithSaltBytes, passwordByte.Length);
                Array.Copy(saltByte,0, passwordWithSaltBytes, passwordByte.Length, saltByte.Length);

                byte[] hashPassword = sha512.ComputeHash(passwordByte);

                return Convert.ToBase64String(hashPassword);
            }
        }

    }
}
