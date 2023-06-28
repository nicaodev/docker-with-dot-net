namespace dockerContainer.Model;

public class TesteDockerDto
{
    public TesteDockerDto()
    {
    }

    public TesteDockerDto(long id, string descricao, string comando, string programador)
    {
        Id = id;
        Descricao = descricao;
        Comando = comando;
        Programador = programador;
    }

    public TesteDockerDto(string descricao, string comando, string programador)
    {
        Descricao = descricao;
        Comando = comando;
        Programador = programador;
    }

    public long Id { get; set; }
    public string? Descricao { get; set; }
    public string? Comando { get; set; }

    public string? Programador { get; set; }
}