import { useState, createContext, ReactNode, useEffect } from 'react';
import IMusic from '../Types/music';

interface IMusicContext {
    currentMusic: IMusic | null;
    allMusics: IMusic[];
    playing: boolean;
    details: string;
    ChangeMusic: (item : IMusic) => void;
    Pause: () => void;
    Play: () => void;
    setMusics: (music: IMusic[]) => void;
    ClosePlayer: () => void;
    updateMusics: (musicResponse: any) => void;
    ShowMusicDetails: () => void;
}

export const MusicContext = createContext({} as IMusicContext);
MusicContext.displayName = 'MusicContext';

export const MusicProvider = ({ children } : { children: ReactNode }) => {
    const [currentMusic, setCurrentMusic] = useState<IMusic | null>(null);
    const [allMusics, setMusics] = useState<IMusic[]>([]);
    const [playing, setPlaying] = useState<boolean>(false);
    const [details, setDetails] = useState<string>('none');

    function ChangeMusic(music: IMusic) {
        sessionStorage.setItem("@MUSIC", JSON.stringify(music));
        setCurrentMusic(music);
        setPlaying(true);
    }

    useEffect(() => {
        const lastMusic = sessionStorage.getItem("@MUSIC");
        console.log("MusicProvider:  :"+lastMusic);

        if (lastMusic) {
            try {
                setCurrentMusic(JSON.parse(lastMusic));
            } catch (error) {
                console.error("Erro ao carregar música do sessionStorage", error);
            }
        }
    }, []);
   
    useEffect(() => {
        const handleBeforeUnload = () => {
          if (currentMusic) {
            sessionStorage.setItem('@MUSIC', JSON.stringify(currentMusic));
            if (playing) {
                Pause()
            }
          }
        };
    
        window.addEventListener('beforeunload', handleBeforeUnload);
    
        return () => {
          window.removeEventListener('beforeunload', handleBeforeUnload);
        };
      }, [currentMusic]);

    function Pause() {
        setPlaying(false);
    }
    function Play() {
        setPlaying(true);
    }

    function ClosePlayer() {
        setMusics([]);
        setCurrentMusic(null);
        sessionStorage.removeItem("@MUSIC");
    }

    function ShowMusicDetails(){
        setDetails(details === 'none' ? 'flex' : 'none')
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
                details,
                setMusics,
                playing,
                ChangeMusic,
                Pause,
                Play,
                ClosePlayer,
                updateMusics,
                ShowMusicDetails
            }}
        >
            {children}
        </MusicContext.Provider>
    )
}