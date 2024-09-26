import { useState } from 'react';
import { api } from '../../Service/api';
import '../../styles/style.css'

export default function UploadMusic2(){

  const [title, setTitle] = useState<string>('');
  const [artist, setArtist] = useState<string>('');
  const [duration, setDuration] = useState<string>('');
  const [year, setYear] = useState<string>('');
  const [lyrics, setLyrics] = useState<string>('');
  const [album, setAlbum] = useState<string>('');
  const [fileInput, setFile] = useState<File | null>();

  const handleSubmit = async (e: { preventDefault: () => void; }) => {
    e.preventDefault();
    
    if (!fileInput) return;
    const payload = {
      Title: title,
      Artist: artist,
      Duration: duration,
      Year: year,
      Lyrics: lyrics,
      Album: album,
    };
    
    try {
      
      const musicResponse = await api.post('http://localhost:5036/music', payload);
      const musicId = musicResponse.data.id; // Captura o ID da música

      console.log('Música criada:', musicResponse.data);

      // Segunda requisição para enviar o arquivo
      const formData = new FormData();
      formData.append('payloadFiles', fileInput); // Nome da chave deve ser o mesmo esperado no backend

      // Envia o arquivo
      const uploadResponse = await api.post(`http://localhost:5036/upload/${musicId}`, formData, {
          headers: {
              'Content-Type': 'multipart/form-data', // Importante para uploads
          },
      });

      console.log('Arquivo enviado:', uploadResponse.data);


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
            <input type="text" onChange={(e) => setTitle(e.target.value)} placeholder="Título" required />
            <input type="text" onChange={(e) => setArtist(e.target.value)} placeholder="Artista" required />
            <input type="text" onChange={(e) => setDuration(e.target.value)} placeholder="Duração" required />
            <input type="text" onChange={(e) => setYear(e.target.value)} placeholder="Ano" required />
            <textarea onChange={(e) => setLyrics(e.target.value)} placeholder="Letra" required />
            <input type="text" onChange={(e) => setAlbum(e.target.value)} placeholder="Álbum" required />
            <br/><br/>
            <label htmlFor="fileInput">Escolha um arquivo de música:</label>
            <input type="file" onChange={ e => setFile(e.target.files?.[0] || null)} id="fileInput" name="payloadFiles" accept="audio/*" multiple required/>
            <br/><br/>
            <button type="submit" onClick={handleSubmit}>Enviar</button>
        </div>

        <footer className="video-margin"></footer>
  
      </div>
    </>
      
  )
}
