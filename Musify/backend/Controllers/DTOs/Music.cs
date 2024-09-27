namespace Musify.DTO;

public record MusicCreatePayload
(
    string Title,
    string Artist,
    string Duration,
    int Year,
    string Lyrics,
    string Album
);

public record MusicCreateResponse
(
    string Message,
    Guid Id
);