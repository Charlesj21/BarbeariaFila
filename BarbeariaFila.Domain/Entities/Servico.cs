namespace BarbeariaFila.Domain.Entities;

public class Servico
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public int DuracaoMinutos { get; private set; }

    private Servico()
    {
        Nome = string.Empty;
    }

    public Servico(string nome, int duracaoMinutos)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do serviço é obrigatório.", nameof(nome));

        if (duracaoMinutos <= 0)
            throw new ArgumentException("A duração deve ser maior que zero.", nameof(duracaoMinutos));

        Nome = nome.Trim();
        DuracaoMinutos = duracaoMinutos;
    }
}