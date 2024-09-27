interface IUser {
    id: string;
    username: string;
    birth: string;
}

interface IMusicHeader {
    id: string;
}

export default interface IMusic {
    id: string;
    title: string;
    artist: string;
    duration: string; // formato: "MM:SS"
    year: number;
    lyrics: string;
    album: string;
    user: IUser;
    musicHeaderId: string;
    musicHeader: IMusicHeader;
}
