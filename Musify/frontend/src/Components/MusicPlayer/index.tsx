import { useContext, useEffect, useRef, useState } from 'react';
import { MusicContext } from '../../Context/MusicContext';
import { ContainerBar, Music } from './styles';
import Hls from 'hls.js';
import { Box } from '@mui/material';
import SliderBuffer from './Components/SliderBuffer';
import SliderProgress from './Components/SliderProgress';
import PlayButton from './Components/PlayButton';

export default function MusicPlayer() {
  const videoRef = useRef<HTMLVideoElement | null>(null);
  const { currentMusic, playing } = useContext(MusicContext);

  const [currentTime, setCurrentTime] = useState(0);
  const [bufferedTime, setBufferedTime] = useState(0);
  const [duration, setDuration] = useState(0);
  const [isSeeking, setIsSeeking] = useState(false);


  useEffect(() => {
    const handleBeforeUnload = () => {
      if (currentMusic) {
        sessionStorage.setItem('@MUSIC', JSON.stringify(currentMusic));
      }
    };

    window.addEventListener('beforeunload', handleBeforeUnload);

    return () => {
      window.removeEventListener('beforeunload', handleBeforeUnload);
    };
  }, [currentMusic]);

  useEffect(() => {
    let hls: Hls | null = null;
    
    if (videoRef.current && currentMusic?.musicHeaderId !== null) {
      const url = `http://localhost:5036/audio/${currentMusic?.musicHeaderId}`;

      if (Hls.isSupported()) {
        hls = new Hls();
        hls.loadSource(url);
        hls.attachMedia(videoRef.current);

        hls.on(Hls.Events.MANIFEST_PARSED, () => {
          
          if (currentMusic) {
            videoRef.current!.currentTime = currentMusic.currentTime; 
          }
          if (playing) {
            videoRef.current?.play();
          }
        });
      } else if (videoRef.current.canPlayType('application/vnd.apple.mpegurl') && currentMusic) {
        videoRef.current.src = url;
        videoRef.current.addEventListener('loadedmetadata', () => {
          videoRef.current!.currentTime = currentMusic?.currentTime;
          if (playing) {
            videoRef.current?.play();
          }
        });
      }

      const handleTimeUpdate = () => {
        if (!isSeeking) {
          setCurrentTime(videoRef.current?.currentTime || 0);
          if (currentMusic) {
            currentMusic.currentTime = videoRef.current?.currentTime || 0;
          }
        }
      };

      const handleProgress = () => {
        const buffered = videoRef.current?.buffered;
        const currentBuffer = buffered && buffered.length > 0 ? buffered.end(buffered.length - 1) : 0;
        setBufferedTime(currentBuffer);
      };

      const handleLoadedMetadata = () => {
        setDuration(videoRef.current?.duration || 0);
      };

      videoRef.current.addEventListener('timeupdate', handleTimeUpdate);
      videoRef.current.addEventListener('progress', handleProgress);
      videoRef.current.addEventListener('loadedmetadata', handleLoadedMetadata);

      return () => {
        if (hls) hls.destroy();
        videoRef.current?.removeEventListener('timeupdate', handleTimeUpdate);
        videoRef.current?.removeEventListener('progress', handleProgress);
        videoRef.current?.removeEventListener('loadedmetadata', handleLoadedMetadata);
      };
    }
  }, [currentMusic]);

  // Effect to control play/pause based on 'playing' state
  useEffect(() => {
    
    if (videoRef.current) {
      if (playing) {
        videoRef.current.play();
      } else {
        videoRef.current.pause();
      }
    }
  }, [playing]);

  const handleSliderChange = (_event: Event, value: number | number[]) => {
    const newTime = value as number;
    setCurrentTime(newTime);
    if (videoRef.current) {
      videoRef.current.currentTime = newTime;
    }
  };

  const handleSliderCommitted = (_event: Event | React.SyntheticEvent<Element, Event>, value: number | number[]) => {
    if (videoRef.current) {
      videoRef.current.currentTime = value as number;
    }
    setIsSeeking(false);
  };

  return (
    <ContainerBar>
      <PlayButton />
      <Box sx={{ width: '400px', position: 'relative' }}>
        <Music ref={videoRef} controls />
        <SliderBuffer bufferedTime={bufferedTime} duration={duration} />
        <SliderProgress handleSliderCommitted={handleSliderCommitted} currentTime={currentTime} duration={duration} handleSliderChange={handleSliderChange} />
      </Box>
    </ContainerBar>
  );
}
