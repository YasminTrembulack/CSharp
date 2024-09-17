using System;
using System.Collections.Generic;

namespace EntityFramework.Model;

public partial class Equipamento
{
    public string Idequipamento { get; set; } = null!;

    public string? Idsala { get; set; }

    public string Nome { get; set; } = null!;

    public string? Tipo { get; set; }

    public virtual ICollection<EventoEquipamento> EventoEquipamentos { get; set; } = new List<EventoEquipamento>();

    public virtual Sala? IdsalaNavigation { get; set; }
}
