namespace Musify.DTO;
public record CreateUserResponde
(
    string Message,
    Guid Data
);

public record UserDTO
(
    string Username,
    string FullName,
    string Password,
    string BirthDate,
    string Role
);

public record UserResponse
(
    Guid Id,
    string Username,
    DateTime BirthDate,
    string Role
);