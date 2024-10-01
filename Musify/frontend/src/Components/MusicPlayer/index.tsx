import { ContainerBar } from './styles';
import PlayButton from './Components/PlayButton';
import MusicProgressLine from '../MusicProgressLine';
import { SlideTopDiv } from './Components/MusicInfo/styles';

export default function MusicPlayer() {

  return (<>
    <SlideTopDiv/>
    <ContainerBar>
      <PlayButton />
      <MusicProgressLine/>
    </ContainerBar>
  </>
  );
}
