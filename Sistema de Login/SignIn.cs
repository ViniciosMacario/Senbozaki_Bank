using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Senbozaki_Bank.Sistema_de_Login
{
    public class SignIn
    {
        //State se o usuário está Autenticado ou não.
        public static bool StateAutenticacao = false;

        //State do nível de acesso do usuário, nível 0 = comum, 1 = admin.
        public static int LevelAutenticao = 0;

    }
}
