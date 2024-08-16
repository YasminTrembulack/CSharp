using Genesis.Domain.Models;

namespace Csharp_bd.Domain.Models;

public partial class Cliente : IEntity
{
  public int ID { get; set; }
  public string Nome { get; set; }
  public string Senha { get; set; }
  public System.DateTime DataNasc { get; set; }
}
