import { useEffect } from 'react';
import MusicTemp from '../../Temp/musics.json'
import CardMusic from './Components/CardMusic'
import { MainContainer, MusicsContainer } from './styles';

export default function Home()
{
    useEffect(() => {
        getMusics();
    }, []);
    function getMusics(){
        return MusicTemp.data.map( m =>
            <CardMusic key={m.album+m.title} musicData={m}/>
        )
    }




    return (
        <MainContainer>
            <MusicsContainer>

                {getMusics()}
            </MusicsContainer>
        
        </MainContainer>
    )
}