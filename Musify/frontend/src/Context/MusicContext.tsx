import { useState, createContext, ReactNode } from 'react';
import IMusic from '../Types/music';

interface IMusicContext {
    currentMusic: IMusic | null;
    allMusics: IMusic[] | null;
    playing: boolean
    Play: (item : IMusic) => void;
    Pause: () => void;
    setMusics: (music: IMusic[]) => void;
    ClosePlayer: () => void;
}

export const MusicContext = createContext({} as IMusicContext);
MusicContext.displayName = 'MusicContext';

export const MusicProvider = ({ children } : { children: ReactNode }) => {
    const [currentMusic, setCurrentMusic] = useState<IMusic | null>(null);
    const [allMusics, setMusics] = useState<IMusic[] | null>(null);
    const [playing, setPlaying] = useState<boolean>(false);
    
    function Play(music: IMusic) {
        setCurrentMusic(music);
        setPlaying(true);
    }

    function Pause() {
        setPlaying(false);
    }

    function ClosePlayer() {
        setMusics(null);
        setCurrentMusic(null);
    }
   
    return (
        <MusicContext.Provider
            value={{
                currentMusic,
                allMusics,
                setMusics,
                playing,
                Play,
                Pause,
                ClosePlayer
            }}
        >
            {children}
        </MusicContext.Provider>
    )
}