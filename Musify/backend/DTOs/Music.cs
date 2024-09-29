namespace Musify.DTO;

public record MusicCreatePayload
(
    string Title,
    string Artist,
    int Year,
    string Lyrics,
    string Album
);

public record MusicCreateResponse
(
    string Message,
    Guid Id
);