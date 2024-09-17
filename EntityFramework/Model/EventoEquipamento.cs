using System;
using System.Collections.Generic;

namespace EntityFramework.Model;

public partial class EventoEquipamento
{
    public string IdeventoEquipamento { get; set; } = null!;

    public string Idevento { get; set; } = null!;

    public string Idequipamento { get; set; } = null!;

    public virtual Equipamento IdequipamentoNavigation { get; set; } = null!;

    public virtual Evento IdeventoNavigation { get; set; } = null!;
}
