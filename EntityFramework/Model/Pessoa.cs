using System;
using System.Collections.Generic;

namespace EntityFramework.Model;

public partial class Pessoa
{
    public string Idpessoa { get; set; } = null!;

    public string Nome { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public virtual ICollection<EventoPessoa> EventoPessoas { get; set; } = new List<EventoPessoa>();
}
