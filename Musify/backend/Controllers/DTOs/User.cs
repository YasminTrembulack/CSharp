
using Musify.Models;

namespace Musify.DTO;
public record CreateUserResponde
(
    string Message,
    Guid Data
);

public record UserDTO
(
    string Username,
    string Password,
    string BirthDate,
    string Role
);