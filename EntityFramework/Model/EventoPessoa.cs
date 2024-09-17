using System;
using System.Collections.Generic;

namespace EntityFramework.Model;

public partial class EventoPessoa
{
    public string IdeventoPessoa { get; set; } = null!;

    public string Idevento { get; set; } = null!;

    public string Idpessoa { get; set; } = null!;

    public string PapelEvento { get; set; } = null!;

    public bool Presenca { get; set; }

    public virtual Evento IdeventoNavigation { get; set; } = null!;

    public virtual Pessoa IdpessoaNavigation { get; set; } = null!;
}
