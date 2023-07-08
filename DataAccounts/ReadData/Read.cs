namespace Senbozaki_Bank.DataAccounts.ReadData
{
    public static class Read
    {
        public static List<Cliente> ReadData()
        {

            List<Cliente> list = new();


            string[] linhas = File.ReadAllLines("../../../DataAccounts/Contas.txt");

            foreach (string line in linhas)
            {
                string[] parts = line.Split(",");
                list.Add(new Cliente
                {
                    numeroDaAgencia = parts[0],
                    numeroDaConta = parts[1],
                    saldo = parts[2],
                    Titular = parts[3]
                }
                );
            }
            Banco_de_Dados.ConnectDB.InitialConnectionDB(list);
            return list;
        }

        //Tipando o Objeto Cliente
        public class Cliente
        {
            public  string? Titular { get; set; }
            public  string? numeroDaAgencia { get; set; }
            public  string? numeroDaConta { get; set; }
            public  string? saldo { get; set; }
        }

    }
}