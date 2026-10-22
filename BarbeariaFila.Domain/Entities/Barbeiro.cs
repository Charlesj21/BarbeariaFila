namespace BarbeariaFila.Domain.Entities;

public class Barbeiro
{
    public int Id { get; private set; }
    public string Nome { get; private set; }
    public bool Ativo { get; private set; }

    private Barbeiro()
    {
        Nome = string.Empty;
    }

    public Barbeiro(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
            throw new ArgumentException("O nome do barbeiro é obrigatório.", nameof(nome));

        Nome = nome.Trim();
        Ativo = true;
    }

    public void Ativar() => Ativo = true;

    public void Desativar() => Ativo = false;
}