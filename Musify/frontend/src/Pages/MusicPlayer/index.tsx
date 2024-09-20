import { useEffect, useRef } from 'react';
import Hls from 'hls.js';


export default function PlayMusic() {
  const videoRef = useRef<HTMLVideoElement | null>(null);
  const url = "http://localhost:5036/music/63FDCD59-318D-47E9-672C-08DCD998FF32";

  useEffect(() => {
    var hls: Hls | null = null;


    if (videoRef.current) {
      // Verifica se o navegador suporta HLS nativamente
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
    }

    return () => {
      if (hls) {
        hls.destroy();
      }
    };
  }, [url]);

    return <video ref={videoRef} controls style={{ width: '100%' }} />;
};

