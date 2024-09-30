using Musify.Models;

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
    MusicResponse Music
);

public record MusicResponse
(
    Guid Id,
    string Title,
    string Artist,
    string Duration,
    int Year,
    string? Lyrics,
    string Album,
    UserResponse User,
    Guid? MusicHeaderId
){
    public static MusicResponse Build(Music music){

        var user =  new UserResponse(
            music.User.Id, 
            music.User.Username, 
            music.User.BirthDate, 
            music.User.Role
        );
        return new MusicResponse(
            music.Id,
            music.Title,
            music.Artist,
            music.Duration,
            music.Year,
            music.Lyrics,
            music.Album,
            user,
            music.MusicHeaderId 
        );
    }
};

public record MusicGetResponse
(
    IEnumerable<Music> Musics,
    int NumberOfMusics
);