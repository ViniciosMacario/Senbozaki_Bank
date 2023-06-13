public class Read
{
  public static List<Cliente> ReadData(){
  
    List<Cliente> list = new List<Cliente>();


    string[] linhas = File.ReadAllLines("../../../Data/Contas.txt");
    
      foreach(string line in linhas)
      {
        string[] parts = line.Split(",");
            list.Add(new Cliente
                {
                    numeroDaAgencia = parts[0],
                    numeroDaConta   = parts[1],
                    saldo           = parts[2],
                    Titular         = parts[3]
                }
            );

      }

        return list;
  }

    //Tipando o Objeto Cliente
    public class Cliente
    {
        public string? Titular           { get; set; }
        public string? numeroDaAgencia   { get; set; }
        public string? numeroDaConta     { get; set; }
        public string? saldo             { get; set; }
    }

}