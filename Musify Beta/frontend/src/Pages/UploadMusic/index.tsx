import { useState } from 'react';
import '../../styles/style.css'

export default function UploadMusic(){

    const [id, setId] = useState<string>('');
    const [title, setTitle] = useState<string>('aaa');
    const [artist, setArtist] = useState<string>('aaa');
    const [duration, setDuration] = useState<string>('123');
    const [year, setYear] = useState<string>('123');
    const [lyrics, setLyrics] = useState<string>('aaa');
    const [album, setAlbum] = useState<string>('aaaaaa');

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
        console.log(payload)
    
        try {
          const response = await fetch('http://localhost:5036/music-info', {
            method: 'POST',
            headers: {
              'Content-Type': 'application/json',
            },
            body: JSON.stringify(payload),
          });

          let json = await response.json();
          console.log(json)
          setId(json.id)
          console.log(id)


        } catch (error) {
          console.error('Erro ao enviar dados:', error);
        }
    };
    
    return (
        <>
            <div className="main-container">

            <header className="video-margin"></header>

            <div className="video-container">
                <h1>Upload de Música</h1>
                <form id="uploadForm" encType="multipart/form-data" method="post" action={`http://localhost:5036/upload/07C0EBED-CF9C-42F0-82DC-1DDA756D3F51`}>
                    <label htmlFor="fileInput">Escolha um arquivo de música:</label>
                    <input type="file" id="fileInput" name="payloadFiles" accept="audio/*" multiple required/>
                    <br/><br/>
                    <button type="submit">Enviar</button>
                </form>
            </div>
            
            <input type="text" onChange={(e) => setTitle(e.target.value)} placeholder="Título" required />
            <input type="text" onChange={(e) => setArtist(e.target.value)} placeholder="Artista" required />
            <input type="text" onChange={(e) => setDuration(e.target.value)} placeholder="Duração" required />
            <input type="text" onChange={(e) => setYear(e.target.value)} placeholder="Ano" required />
            <textarea onChange={(e) => setLyrics(e.target.value)} placeholder="Letra" required />
            <input type="text" onChange={(e) => setAlbum(e.target.value)} placeholder="Álbum" required />
            <br/><br/>
            <button type="submit" onClick={handleSubmit}>Enviar</button>

            <footer className="video-margin"></footer>
        
            </div>
        </>
    )
}