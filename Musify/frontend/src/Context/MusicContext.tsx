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
        setCurrentMusic(music);
        setPlaying(true);
        sessionStorage.setItem("@MUSIC", JSON.stringify(music));
        sessionStorage.setItem("@MUSICTIME", '0');
    }

    useEffect(() => {
        const lastMusic = sessionStorage.getItem("@MUSIC");
        if (lastMusic) {
            setCurrentMusic(JSON.parse(lastMusic));
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

    const updateMusics = (musicResponse: any) => {
        if (allMusics.length === 0) {
            setMusics(musicResponse);
        } else if (allMusics.length < 10) {
            setMusics(prev => {
                const newMusic = Array.isArray(musicResponse) 
                    ? musicResponse 
                    : [musicResponse];
                return [...prev, ...newMusic]; 
            });
        }
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