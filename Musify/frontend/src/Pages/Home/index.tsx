import { useContext, useEffect } from 'react';
import { AsideLeft, AsideRight, MainContainer, MusicsContainer } from './styles';
import { MusicContext } from '../../Context/MusicContext';
import CardMusic from './Components/CardMusic'
import { getHeaders } from '../../Service/headers';
import { api } from '../../Service/api';
import AddMusicButton from './Components/AddMusicButton';
// import MusicTemp from '../../Temp/musics.json'

export default function Home()
{
    const { allMusics, setMusics } = useContext(MusicContext);

    useEffect(() => {
        fetchMusics(1, 10);
    }, []);


    async function fetchMusics(index: number, size: number) {
        const response = await api.get('/music',{
            params:{
                pageIndex: index,
                pageSize: size
            },
            headers: getHeaders()
        }); 
        setMusics(response.data);
    }

    function getMusics(){
        if (allMusics) 
            return allMusics.map( m =>
                <CardMusic key={m.id} musicData={m}/>
            )
    }

    return (
        <MainContainer>
            <AsideLeft>
            </AsideLeft>
            <MusicsContainer>
                {getMusics()}
            </MusicsContainer>
            <AsideRight>
                <AddMusicButton/>
            </AsideRight>
        </MainContainer>
    )
}