import { ContainerBar } from './styles';
import PlayButton from './Components/PlayButton';
import MusicProgressLine from '../MusicProgressLine';
import { useContext } from 'react';
import MusicInfo from './Components/MusicInfo';
import KeyboardArrowUpIcon from '@mui/icons-material/KeyboardArrowUp';
import { MusicContext } from '../../Context/MusicContext';

export default function MusicPlayer() {

  const { ShowMusicDetails } =  useContext(MusicContext);


  return (<>
    <ContainerBar>
      <PlayButton />
      <MusicProgressLine/>
      <KeyboardArrowUpIcon onClick={ShowMusicDetails}/>
    </ContainerBar>
    <MusicInfo/>
  </>
  );
}
