interface IUser {
    id: string;
    username: string;
    birth: string;
}


export default interface IMusic {
    id: string;
    title: string;
    artist: string;
    duration: string; 
    year: number;
    lyrics: string;
    album: string;
    user: IUser;
    musicHeaderId: string;
    currentTime: number;
}
