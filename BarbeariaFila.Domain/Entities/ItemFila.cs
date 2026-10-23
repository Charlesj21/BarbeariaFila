using BarbeariaFila.Domain.Enums;

namespace BarbeariaFila.Domain.Entities;

public class ItemFila
{
    public int Id { get; private set; }
    public int ServicoId { get; private set; }
    public Servico Servico { get; private set; } = null!;
    public StatusFila Status { get; private set; }
    public DateTime ChegouEm { get; private set; }
    public DateTime? IniciouEm { get; private set; }
    public DateTime? FinalizouEm { get; private set; }

    private ItemFila()
    {
    }

    public ItemFila(int servicoId)
    {
        if (servicoId <= 0)
            throw new ArgumentException("O serviço é obrigatório.", nameof(servicoId));

        ServicoId = servicoId;
        Status = StatusFila.Aguardando;
        ChegouEm = DateTime.UtcNow;
    }

    public void IniciarAtendimento()
    {
        if (Status != StatusFila.Aguardando)
            throw new InvalidOperationException("Só é possível iniciar quem está aguardando.");

        Status = StatusFila.EmAtendimento;
        IniciouEm = DateTime.UtcNow;
    }

    public void Finalizar()
    {
        if (Status != StatusFila.EmAtendimento)
            throw new InvalidOperationException("Só é possível finalizar quem está em atendimento.");

        Status = StatusFila.Finalizado;
        FinalizouEm = DateTime.UtcNow;
    }

    public void Cancelar()
    {
        if (Status is StatusFila.Finalizado or StatusFila.Cancelado)
            throw new InvalidOperationException("Este item da fila já foi encerrado.");

        Status = StatusFila.Cancelado;
        FinalizouEm = DateTime.UtcNow;
    }
}