using Genesis.Core.Repositories;
using Csharp_bd.Domain.Repositories;
using Csharp_bd.Domain.Models;

namespace Csharp_bd.Core.Repositories;

public class ClienteRepository(exampleContext context) 
    : BaseRepository<Cliente>(context), IClienteRepository
{

}
