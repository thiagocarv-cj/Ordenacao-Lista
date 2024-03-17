
class Program
{
    static void Main(string[] args)
    {        
        List<Cliente> clientes = new List<Cliente>();
        
        clientes.Add(new Cliente("Pedro", new DateTime(1999, 9, 28)));
        clientes.Add(new Cliente("Maria", new DateTime(2003, 1, 12)));
        clientes.Add(new Cliente("João", new DateTime(1991, 3, 7)));
        clientes.Add(new Cliente("Tiago", new DateTime(2000, 12, 15)));
        clientes.Add(new Cliente("Helena", new DateTime(2003, 12, 6)));
        clientes.Add(new Cliente("Paula", new DateTime(2003, 9, 13)));
        
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Nome: {cliente.Nome}");
            Console.WriteLine($"Data de Nascimento: {cliente.DataNascimento.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Idade: {cliente.CalcularIdade()} anos\n");
        }

        RemoverClientePorNome(clientes, "Maria");
        ImprimirClientesEmOrdemAlfabetica(clientes);
        ImprimirClientesMaioresDeIdade(clientes);
        ImprimirClienteMaiorIdade(clientes);
        ImprimirClienteMenorIdade(clientes);
    }
    static void RemoverClientePorNome(List<Cliente> clientes, string nome)
    {        
        Cliente clienteRemover = clientes.Find(c => c.Nome == nome);

        if (clienteRemover != null)
        {
            clientes.Remove(clienteRemover);
            Console.WriteLine($"Cliente '{nome}' removido!");
        }
        else
        {
            Console.WriteLine($"Cliente '{nome}' não encontrado.");
        }
    }

    static void ImprimirClientesEmOrdemAlfabetica(List<Cliente> clientes)
    {        
        clientes.Sort((c1, c2) => string.Compare(c1.Nome, c2.Nome));
       
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"Nome: {cliente.Nome}");
            Console.WriteLine($"Data de Nascimento: {cliente.DataNascimento.ToString("dd/MM/yyyy")}");
            Console.WriteLine($"Idade: {cliente.CalcularIdade()} anos\n");
        }
    }

    static void ImprimirClientesMaioresDeIdade(List<Cliente> clientes)
    {        
        foreach (var cliente in clientes)
        {            
            if (cliente.CalcularIdade() >= 18)
            {
                Console.WriteLine($"Nome: {cliente.Nome}");
                Console.WriteLine($"Data de Nascimento: {cliente.DataNascimento.ToString("dd/MM/yyyy")}");
                Console.WriteLine($"Idade: {cliente.CalcularIdade()} anos\n");
            }
        }
    }

    static void ImprimirClienteMaiorIdade(List<Cliente> clientes)
    {
        Cliente clienteMaiorIdade = clientes[0];
       
        foreach (var cliente in clientes)
        {
            if (cliente.CalcularIdade() > clienteMaiorIdade.CalcularIdade())
            {
                clienteMaiorIdade = cliente;
            }
        }

        Console.WriteLine($"Cliente com a maior idade: {clienteMaiorIdade.Nome}");    
    }

    static void ImprimirClienteMenorIdade(List<Cliente> clientes)
    {
        Cliente clienteMenorIdade = clientes[0];
        
        foreach (var cliente in clientes)
        {
            if (cliente.CalcularIdade() < clienteMenorIdade.CalcularIdade())
            {
                clienteMenorIdade = cliente;
            }
        }
       
        Console.WriteLine($"Cliente com a menor idade: {clienteMenorIdade.Nome}");        
        
    }
}
class Cliente
{
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }

    public Cliente(string nome, DateTime dataNascimento)
    {
        Nome = nome;
        DataNascimento = dataNascimento;
    }

    public int CalcularIdade()
    {
        DateTime hoje = DateTime.Today;
        int idade = hoje.Year - DataNascimento.Year;
        if (DataNascimento.Date > hoje.AddYears(-idade))
            idade--;
        return idade;
    }
}

