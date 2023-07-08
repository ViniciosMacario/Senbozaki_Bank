using System.Data;
using System.Data.SqlClient;
using Senbozaki_Bank.DataAccounts.ReadData;

namespace Senbozaki_Bank.Banco_de_Dados
{
    public static class ConnectDB
    {
        const string connectionString = "Data Source=IMPERADOR-DESKT;Initial Catalog=ContasSenbozaki;Uid=sa;Password=jackson_10";

        public static void InitialConnectionDB(List<Read.Cliente> Acctouns)
        {
            try
            {
                SqlConnection connection = new(connectionString);
                connection.Open();

                var State = connection.State == ConnectionState.Open;

                // A conexão foi estabelecida com sucesso
                Console.WriteLine("Conexão estabelecida com sucesso.");

                string insertQuery = "INSERT INTO Users (id,titular,numero_da_agencia,numero_da_conta) VALUES (@Valor1, @Valor2, @Valor3, @Valor4)";



                // Adicione os parâmetros correspondentes aos valores que você deseja inserir


                    using (SqlCommand command = new(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@Valor1", "");
                        command.Parameters.AddWithValue("@Valor2", "");
                        command.Parameters.AddWithValue("@Valor3", "");
                        command.Parameters.AddWithValue("@Valor4", "");

                    foreach (var user in Acctouns)
                    {
                        // Atualizar os valores dos parâmetros para cada elemento da lista
                        command.Parameters["@Valor1"].Value = user.numeroDaAgencia + user.numeroDaConta;
                        command.Parameters["@Valor2"].Value = user.Titular;
                        command.Parameters["@Valor3"].Value = user.numeroDaAgencia;
                        command.Parameters["@Valor4"].Value = user.numeroDaConta;

                        // Execute o comando para cada item
                        command.ExecuteNonQuery();
                    }

                    connection.Close();

                    /*
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine("teste");
                        }
                    }
                    */
                }
            }
            catch (Exception ERRO)
            {
                throw new Exception($"{ERRO}");
            }
        }
    }
}
