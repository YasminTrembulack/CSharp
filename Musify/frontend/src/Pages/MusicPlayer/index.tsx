import { useEffect, useRef } from 'react';
import Hls from 'hls.js';
import { Music } from './styles';
import '../../styles/style.css'
import { useParams } from 'react-router';


export default function PlayMusic() {
  const videoRef = useRef<HTMLVideoElement | null>(null);

  const { id } = useParams();

  const url = `http://localhost:5036/music/${id}`;

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

    return(
      <div className="main-container">

        <header className="video-margin"></header>
        <div className="video-container">

          <Music ref={videoRef} controls />
        </div>
        <footer className="video-margin"></footer>
        
      </div>
    )
};

