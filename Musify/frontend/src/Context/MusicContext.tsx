import { useState, createContext, ReactNode, useEffect } from 'react';
import IMusic from '../Types/music';

interface IMusicContext {
    currentMusic: IMusic | null;
    allMusics: IMusic[];
    playing: boolean
    ChangeMusic: (item : IMusic) => void;
    Pause: () => void;
    Play: () => void;
    setMusics: (music: IMusic[]) => void;
    ClosePlayer: () => void;
    updateMusics: (musicResponse: any) => void;
}

export const MusicContext = createContext({} as IMusicContext);
MusicContext.displayName = 'MusicContext';

export const MusicProvider = ({ children } : { children: ReactNode }) => {
    const [currentMusic, setCurrentMusic] = useState<IMusic | null>(null);
    const [allMusics, setMusics] = useState<IMusic[]>([]);
    const [playing, setPlaying] = useState<boolean>(false);
    
    function ChangeMusic(music: IMusic) {
        music.currentTime = 0;
        setCurrentMusic(music);
        setPlaying(true);
    }

    // Recupera a música da sessão ao carregar a página
    useEffect(() => {
        const lastMusic = sessionStorage.getItem("@MUSIC");
        console.log(lastMusic);

        if (lastMusic) {
            try {
                setCurrentMusic(JSON.parse(lastMusic));
            } catch (error) {
                console.error("Erro ao carregar música do sessionStorage", error);
            }
        }
    }, []);

    function Pause() {
        setPlaying(false);
    }
    function Play() {
        setPlaying(true);
    }

    function ClosePlayer() {
        setMusics([]);
        setCurrentMusic(null);
    }

    const updateMusics = (musicResponse: IMusic | IMusic[]) => {
        setMusics((prev) => {
            const newMusicArray = Array.isArray(musicResponse) 
                ? musicResponse 
                : [musicResponse];

            // Evita duplicações
            const filteredMusic = newMusicArray.filter((newMusic) =>
                !prev.some((music) => music.id === newMusic.id)
            );

            return [...prev, ...filteredMusic];
        });
    };
   
    return (
        <MusicContext.Provider
            value={{
                currentMusic,
                allMusics,
                setMusics,
                playing,
                ChangeMusic,
                Pause,
                Play,
                ClosePlayer,
                updateMusics
            }}
        >
            {children}
        </MusicContext.Provider>
    )
}