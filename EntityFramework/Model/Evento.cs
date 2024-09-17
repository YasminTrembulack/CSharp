using System;
using System.Collections.Generic;

namespace EntityFramework.Model;

public partial class Evento
{
    public string Idevento { get; set; } = null!;

    public string Idsala { get; set; } = null!;

    public string Descricao { get; set; } = null!;

    public DateTime DtHrInicio { get; set; }

    public DateTime DtHrFim { get; set; }

    public virtual ICollection<EventoEquipamento> EventoEquipamentos { get; set; } = new List<EventoEquipamento>();

    public virtual ICollection<EventoPessoa> EventoPessoas { get; set; } = new List<EventoPessoa>();

    public virtual Sala IdsalaNavigation { get; set; } = null!;
}
