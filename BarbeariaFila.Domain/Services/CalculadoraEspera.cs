using BarbeariaFila.Domain.Entities;
using BarbeariaFila.Domain.Enums;

namespace BarbeariaFila.Domain.Services;

public static class CalculadoraEspera
{
    public static int EstimarMinutos(IEnumerable<ItemFila> naFrente, int barbeirosAtivos, DateTime agora)
    {
        var totalMinutos = 0.0;

        foreach (var item in naFrente)
        {
            if (item.Status == StatusFila.EmAtendimento && item.IniciouEm.HasValue)
            {
                var decorrido = (agora - item.IniciouEm.Value).TotalMinutes;
                totalMinutos += Math.Max(item.Servico.DuracaoMinutos - decorrido, 0);
            }
            else if (item.Status == StatusFila.Aguardando)
            {
                totalMinutos += item.Servico.DuracaoMinutos;
            }
        }

        var barbeiros = Math.Max(barbeirosAtivos, 1);
        return (int)Math.Ceiling(totalMinutos / barbeiros);
    }
}