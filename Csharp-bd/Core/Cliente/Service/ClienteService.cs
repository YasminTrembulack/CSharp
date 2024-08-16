using Genesis.Core.Services;
using Genesis.Core.Repositories;
using Csharp_bd.Domain.Models;
using Csharp_bd.Domain.Services;

namespace Csharp_bd.Core.Services;

public class ClienteService(BaseRepository<Cliente> repository)
    : BaseService<Cliente> (repository), IClienteService
{

}
