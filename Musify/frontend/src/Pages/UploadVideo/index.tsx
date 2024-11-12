import { useState } from 'react';
import { api } from '../../Service/api';
import '../../styles/style.css'
import axios from 'axios';

export default function UploadVideo(){

  const [title, setTitle] = useState<string>('');
  const [lyrics, setLyrics] = useState<string>('');
  const [contentId, setContentId] = useState<string>('ac12b720-9dc6-11ef-abcf-cecd02c24f20');
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
      const musicId = musicResponse.data.video.id; // Captura o ID da música

      console.log('Video criada:', musicResponse.data);
      console.log(musicResponse.data.video.id);
      

      // Segunda requisição para enviar o arquivo
      const formData = new FormData();
      formData.append('payloadFiles', fileInput); // Nome da chave deve ser o mesmo esperado no backend

      // Envia o arquivo
      const uploadResponse = await axios.post(`http://localhost:5217/upload/${musicId}`, formData, {
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
