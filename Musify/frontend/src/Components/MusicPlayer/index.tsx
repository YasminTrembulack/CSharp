import { useContext, useEffect, useRef, useState } from 'react';
import { MusicContext } from '../../Context/MusicContext';
import { Container, Music } from './styles';
import Hls from 'hls.js';
import { Box } from '@mui/material';
import SliderBuffer from './Components/SliderBuffer';
import SliderProgress from './Components/SliderProgress';

export default function MusicPlayer() {
  const videoRef = useRef<HTMLVideoElement | null>(null);
  const { currentMusic } = useContext(MusicContext);

  const [currentTime, setCurrentTime] = useState(0); // Progresso atual da música
  const [bufferedTime, setBufferedTime] = useState(0); // Progresso do buffer
  const [duration, setDuration] = useState(0); // Duração total da música
  const [isSeeking, setIsSeeking] = useState(false); // Para verificar se o usuário está buscando (seek)

  useEffect(() => {
    let hls: Hls | null = null;

    if (videoRef.current && currentMusic?.musicHeaderId !== null) {
      const url = `http://localhost:5036/audio/${currentMusic?.musicHeaderId}`;

      if (Hls.isSupported()) {
        hls = new Hls();
        hls.loadSource(url);
        hls.attachMedia(videoRef.current);

        hls.on(Hls.Events.MANIFEST_PARSED, () => {
          videoRef.current?.play();
        });
      } else if (videoRef.current.canPlayType('application/vnd.apple.mpegurl')) {
        videoRef.current.src = url;
        videoRef.current.addEventListener('loadedmetadata', () => {
          videoRef.current?.play();
        });
      }

      // Atualiza o progresso da música
      const handleTimeUpdate = () => {
        if (!isSeeking) {
          setCurrentTime(videoRef.current?.currentTime || 0);
        }
      };

      // Atualiza o progresso do buffer
      const handleProgress = () => {
        if (videoRef.current) {
          const buffered = videoRef.current.buffered;
          const currentBuffer = buffered.length > 0 ? buffered.end(buffered.length - 1) : 0;
          setBufferedTime(currentBuffer);
        }
      };

      // Define a duração total quando estiver disponível
      const handleLoadedMetadata = () => {
        setDuration(videoRef.current?.duration || 0);
      };

      // Eventos
      videoRef.current.addEventListener('timeupdate', handleTimeUpdate);
      videoRef.current.addEventListener('progress', handleProgress);
      videoRef.current.addEventListener('loadedmetadata', handleLoadedMetadata); // Obtém a duração total

      // Limpa os eventos ao desmontar
      return () => {
        if (hls) {
          hls.destroy();
        }
        if (videoRef.current) {
          videoRef.current.removeEventListener('timeupdate', handleTimeUpdate);
          videoRef.current.removeEventListener('progress', handleProgress);
          videoRef.current.removeEventListener('loadedmetadata', handleLoadedMetadata);
        }
      };
    }
  }, [currentMusic, isSeeking]);

  // Função chamada ao mover o slider
  const handleSliderChange = (_event: Event, value: number | number[]) => {
    setIsSeeking(true); // Indica que estamos buscando (seek)
    setCurrentTime(value as number); // Atualiza o tempo do slider
  };

  // Função chamada ao soltar o slider (confirmar a nova posição)
  const handleSliderCommitted = ( _event: Event | React.SyntheticEvent<Element, Event>,
    value: number | number[]) => {
    if (videoRef.current) {
      videoRef.current.currentTime = value as number; // Atualiza o currentTime do vídeo
    }
    setIsSeeking(false); // Finaliza o seek
  };

  return (
    <Container>
      {currentMusic !== null && (
        <>
          <Music ref={videoRef} controls />

            <Box sx={{ width: '100%', position: 'relative' }}>
                <SliderBuffer bufferedTime={bufferedTime} duration={duration}/>
                <SliderProgress handleSliderCommitted={handleSliderCommitted} currentTime={currentTime} duration={duration} handleSliderChange={handleSliderChange}/>
            </Box>
        </>
      )}
    </Container>
  );
}
