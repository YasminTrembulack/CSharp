import { useState } from 'react';
import '../../styles/style.css'

export default function UploadMusic2(){

    const [title, setTitle] = useState<string>('');
    const [artist, setArtist] = useState<string>('');
    const [duration, setDuration] = useState<string>('');
    const [year, setYear] = useState<string>('');
    const [lyrics, setLyrics] = useState<string>('');
    const [album, setAlbum] = useState<string>('');
    const [files, setFile] = useState<File | undefined | null>();

  const handleSubmit = async (e: { preventDefault: () => void; }) => {
    e.preventDefault();
    
    const payload = {
      Title: title,
      Artist: artist,
      Duration: duration,
      Year: year,
      Lyrics: lyrics,
      Album: album,
    };

    if (!files) return;

    const formData = new FormData();
    formData.append('file', files); 

    try {
      const response = await fetch('http://localhost:5036/music-info', {
        method: 'POST',
        headers: {
          'Content-Type': 'application/json',
        },
        body: JSON.stringify(payload),
      });
      const data = await response.json();
      console.log('File to upload:', files);
      
      const responseUp = await fetch(`http://localhost:5036/upload-music/${data.id}`, {
        method: 'POST',
        body: formData,
        headers: {
            'Content-Type': 'multipart/form-data; boundary=--14737809831466499882746641449'
        }
      });
      const dataUp = await responseUp.json();

      console.log('Resposta do music info:', data);
      console.log('Resposta do upload:', dataUp);
    } catch (error) {
      console.error('Erro ao enviar dados:', error);
    }
  };

  const handleFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const selectedFile = e.target.files?.[0] || null; // Verifica se files não é null
    setFile(selectedFile);
  };

    return (
        <>
            <div className="main-container">

            <header className="video-margin"></header>

            <div className="video-container">
                <h1>Upload de Música</h1>
                <input type="text" onChange={(e) => setTitle(e.target.value)} placeholder="Título" required />
                <input type="text" onChange={(e) => setArtist(e.target.value)} placeholder="Artista" required />
                <input type="text" onChange={(e) => setDuration(e.target.value)} placeholder="Duração" required />
                <input type="text" onChange={(e) => setYear(e.target.value)} placeholder="Ano" required />
                <textarea onChange={(e) => setLyrics(e.target.value)} placeholder="Letra" required />
                <input type="text" onChange={(e) => setAlbum(e.target.value)} placeholder="Álbum" required />
                <br/><br/>
                <label htmlFor="fileInput">Escolha um arquivo de música:</label>
                <input type="file" onChange={handleFileChange} id="fileInput" name="payloadFiles" accept="audio/*" multiple required/>
                <br/><br/>
                <button type="submit" onClick={handleSubmit}>Enviar</button>
            </div>

            <footer className="video-margin"></footer>
        
            </div>
        </>
        
    )
}
