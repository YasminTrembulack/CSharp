import { Slider } from '@mui/material';

export default function MusicPlayer({ bufferedTime, duration } : { bufferedTime : number, duration: number }) {

    return (
        <Slider
            value={bufferedTime} // Progresso do buffer
            min={0}
            max={duration} // Duração total
            sx={{
                width: '400px',
                color: 'rgba(255, 255, 255, 0.5)', // Cor para o buffer (mais clara)
                height: 10,
                '& .MuiSlider-thumb': {
                    display: 'none', // Esconde o thumb para o buffer
                },
                '& .MuiSlider-track': {
                    backgroundColor: 'rgba(255, 255, 255, 0.5)', // Fundo mais claro para o buffer
                },
                '& .MuiSlider-rail': {
                    opacity: 0.3,
                    backgroundColor: 'rgba(255, 255, 255, 0.3)', // Cor da rail
                },
            }}
        />
    );
}
