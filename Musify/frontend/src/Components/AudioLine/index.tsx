import { useContext, useEffect, useRef, useState } from 'react';
import { MusicContext } from '../../Context/MusicContext';
import { Music } from './styles';
import Hls from 'hls.js';
import { Box } from '@mui/material';
import SliderBuffer from './Components/SliderBuffer';
import SliderProgress from './Components/SliderProgress';

export default function AudioLine() {
  const videoRef = useRef<HTMLVideoElement | null>(null);
  const { currentMusic } = useContext(MusicContext);

  const [currentTime, setCurrentTime] = useState(0);
  const [bufferedTime, setBufferedTime] = useState(0);
  const [duration, setDuration] = useState(0);
  const [isSeeking, setIsSeeking] = useState(false);

  useEffect(() => {
    let hls: Hls | null = null;
    console.log(currentMusic);
    
    if (videoRef.current && currentMusic?.musicHeaderId !== null) {
      const lastTime = sessionStorage.getItem("@MUSICTIME");
      const url = `http://localhost:5036/audio/${currentMusic?.musicHeaderId}`;

      if (Hls.isSupported()) {
        hls = new Hls();
        hls.loadSource(url);
        hls.attachMedia(videoRef.current);

        hls.on(Hls.Events.MANIFEST_PARSED, () => {
          if (lastTime) {
            videoRef.current!.currentTime = Number(lastTime); 
          }
          // videoRef.current?.play();
        });
      } else if (videoRef.current.canPlayType('application/vnd.apple.mpegurl')) {
        videoRef.current.src = url;
        videoRef.current.addEventListener('loadedmetadata', () => {
          if (lastTime) {
            videoRef.current!.currentTime = Number(lastTime);
          }
          // videoRef.current?.play();
        });
      }

      const handleTimeUpdate = () => {
        if (!isSeeking) {
          setCurrentTime(videoRef.current?.currentTime || 0);
          sessionStorage.setItem("@MUSICTIME", videoRef.current?.currentTime.toString() || '0');
        }
      };

      const handleProgress = () => {
        if (videoRef.current) {
          const buffered = videoRef.current.buffered;
          const currentBuffer = buffered.length > 0 ? buffered.end(buffered.length - 1) : 0;
          setBufferedTime(currentBuffer);
        }
      };

      const handleLoadedMetadata = () => {
        setDuration(videoRef.current?.duration || 0);
      };

      videoRef.current.addEventListener('timeupdate', handleTimeUpdate);
      videoRef.current.addEventListener('progress', handleProgress);
      videoRef.current.addEventListener('loadedmetadata', handleLoadedMetadata);

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
  }, [currentMusic, isSeeking ]);

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
    <Box sx={{ width: '100%'}}>
      <Music ref={videoRef} controls />
      <SliderBuffer bufferedTime={bufferedTime} duration={duration} />
      <SliderProgress handleSliderCommitted={handleSliderCommitted} currentTime={currentTime} duration={duration} handleSliderChange={handleSliderChange} />
    </Box>
  );
}
