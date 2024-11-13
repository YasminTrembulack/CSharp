import { useState } from 'react';
import '../../styles/style.css'
import axios from 'axios';

export default function UploadVideo(){

  const [title, setTitle] = useState<string>('');
  const [lyrics, setLyrics] = useState<string>('');
  const [contentId] = useState<string>('e7b0d3c8-7f7c-4c73-b4b4-9c8c2c5d9b1a');
  const [fileInput, setFile] = useState<File | null>();

  const handleSubmit = async (e: { preventDefault: () => void; }) => {
    e.preventDefault();
    
    if (!fileInput) return;
    
    const payload = {
      Name: title,
      Description: lyrics,
      TrainingContentId: contentId
    };
    
    try {
      
      const musicResponse = await axios.post('http://localhost:5217/video', payload);
      const videoId = musicResponse.data.video.id; 

      const formData = new FormData();
      formData.append('payloadFiles', fileInput); 


      const uploadResponse = await axios.post(`http://localhost:5217/upload/${videoId}`, formData, {
          headers: {
              'Content-Type': 'multipart/form-data', 
          },
          timeout: 30000,
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
            <h1>Upload de Video</h1>
            <input type="text" onChange={(e) => setTitle(e.target.value)} placeholder="Título" required />
            <textarea onChange={(e) => setLyrics(e.target.value)} placeholder="Letra" required />
            {/* <input type="text" onChange={(e) => setContentId(e.target.value)} placeholder="TrainingContentId" required /> */}
            <br/><br/>
            <label htmlFor="fileInput">Escolha um arquivo de video:</label>
            <input type="file" onChange={ e => setFile(e.target.files?.[0] || null)} id="fileInput" name="payloadFiles" accept="video/*" multiple required/>
            <br/><br/>
            <button type="submit" onClick={handleSubmit}>Enviar</button>
        </div>

        <footer className="video-margin"></footer>
  
      </div>
    </>
      
  )
}
