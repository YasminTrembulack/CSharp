namespace Musify.DTO;

public record LoginPayload
(
    string Username,
    string Password
);

public record LoginResponse
(
    string Token
);