import { BtnSign, FormContainer, Forms, ImpuGroup, Title } from './style';
import CircularButton from '../../../../Components/CircularButton';
import AddIcon from '@mui/icons-material/Add';
import { Modal } from '@mui/material';
import { useState } from 'react';
import { api } from '../../../../Service/api';
import { getHeaders } from '../../../../Service/headers';
import UploadComponent from '../../../../Components/UploadComponent';

export default function AddMusicButton(){
    const [title, setTitle] = useState<string>('');
    const [artist, setArtist] = useState<string>('');
    const [year, setYear] = useState<string>('');
    const [album, setAlbum] = useState<string>('');
    const [lyrics, setLyrics] = useState<string>('');
    const [fileInput, setFile] = useState<File | null>();


    const [open, setOpen] = useState(false);
    const handleOpen = () => setOpen(true);
    const handleClose = () => setOpen(false);

    async function handleSubmit(e: React.FormEvent<HTMLFormElement>){
        e.preventDefault();
        if (!fileInput) return;

        const payload ={
            Title : title,
            Artist : artist,
            Year: year,
            Lyrics : lyrics,
            Album: album
        }

        const musicResponse = await api.post('/music',payload,{
            headers: getHeaders()
        }); 
        const musicId = musicResponse.data.id; 

        console.log(musicResponse.data);

        const formData = new FormData();
        formData.append('payloadFiles', fileInput);

        const uploadResponse = await api.post(`/upload/${musicId}`, formData, {
            headers: {
                'Authorization': `Bearer ${sessionStorage.getItem('@TOKEN')}`,
                'Content-Type': 'multipart/form-data',
            },
        });
        console.log(uploadResponse.data);
        
    }
  
    return(
        <>
            <CircularButton onClick={handleOpen}>
                <AddIcon/>
            </CircularButton>
            <Modal
                open={open}
                onClose={handleClose}
                aria-labelledby="modal-modal-title"
                aria-describedby="modal-modal-description"
            >
                <FormContainer>
                    <Title>Add Music</Title>
                    <Forms onSubmit={handleSubmit}>
                    <ImpuGroup >
                        <label htmlFor="title">Title</label>
                        <input onChange={(e) => setTitle(e.target.value)} type="text" name="username" id="username" placeholder="" />
                    </ImpuGroup>
                    <ImpuGroup>
                        <label htmlFor="artist">Artist</label>
                        <input onChange={(e) => setArtist(e.target.value)} type="text" name="artist" id="artist" placeholder="" />
                    </ImpuGroup>
                    <ImpuGroup>
                        <label htmlFor="album">Album</label>
                        <input onChange={(e) => setAlbum(e.target.value)} type="text" name="album" id="album" placeholder="" />
                    </ImpuGroup>
                    <ImpuGroup>
                        <label htmlFor="year">Year</label>
                        <input onChange={(e) => setYear(e.target.value)} type="number" name="year" id="year" placeholder="" />
                    </ImpuGroup>
                    <ImpuGroup>
                        <label htmlFor="lyrics">Lyrics</label>
                        <textarea onChange={(e) => setLyrics(e.target.value)} cols={34} rows={5} name="lyrics" id="v" placeholder="" />
                    </ImpuGroup>
                    <UploadComponent>
                        <input onChange={ e => setFile(e.target.files?.[0] || null)} name="payloadFiles" required/>
                    </UploadComponent>
                    <BtnSign type='submit' className="sign">Create</BtnSign>
                    </Forms>
                </FormContainer>
            </Modal>
        </>
    )
}


