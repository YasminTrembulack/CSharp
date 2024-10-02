import { ContainerBar } from './styles';
import PlayButton from './Components/PlayButton';
import MusicProgressLine from '../MusicProgressLine';
import { useState } from 'react';
import MusicInfo from './Components/MusicInfo';

export default function MusicPlayer() {
  const [info, setInfo] = useState<string>('none');

  function handlerShowInfo(){
    setInfo(info === 'none' ? 'flex' : 'none')
  }
  return (<>
    <ContainerBar onClick={handlerShowInfo}>
      <PlayButton />
      <MusicProgressLine/>
    </ContainerBar>
    <MusicInfo display={info}/>
  </>
  );
}
