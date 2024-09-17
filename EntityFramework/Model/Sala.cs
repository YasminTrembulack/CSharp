using System;
using System.Collections.Generic;

namespace EntityFramework.Model;

public partial class Sala
{
    public string Idsala { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public int Capacidade { get; set; }

    public virtual ICollection<Equipamento> Equipamentos { get; set; } = new List<Equipamento>();

    public virtual ICollection<Evento> Eventos { get; set; } = new List<Evento>();
}
