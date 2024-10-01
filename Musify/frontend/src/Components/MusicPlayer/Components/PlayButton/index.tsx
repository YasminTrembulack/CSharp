import PlayArrowIcon from '@mui/icons-material/PlayArrow';
import PauseIcon from '@mui/icons-material/Pause';
import { MusicContext } from '../../../../Context/MusicContext';
import { useContext } from 'react';

export default function PlayButton(){
    
  const { playing, Pause, Play } = useContext(MusicContext);

    function handleClick(){
        if (playing) {
            Pause()
        }
        else{
            Play()
        }
    }
    return(
        <div onClick={handleClick}>
            { playing 
                ? <PauseIcon />
                
                : <PlayArrowIcon />
            }
        </div>
    )

}