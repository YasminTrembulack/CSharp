import { Slider } from '@mui/material';

interface ISliderProgress{
  currentTime: number;
  duration: number;
  handleSliderChange: (
    _event: Event, 
    value: number | number[]
  ) => void;
  handleSliderCommitted: ( 
    _event: Event | React.SyntheticEvent<Element, Event>,
    value: number | number[]
  ) => void;
}

export default function SliderProgress({ currentTime, duration, handleSliderChange, handleSliderCommitted }: ISliderProgress) {

  return (
    <Slider
      value={currentTime} // Progresso atual da música
      min={0}
      step={1}
      max={duration} // Duração total
      onChange={handleSliderChange} // Atualiza o slider enquanto o usuário o move
      onChangeCommitted={handleSliderCommitted} // Atualiza o vídeo quando o usuário solta o slider
      sx={{
      position: 'absolute',
      top: 0,
      left: 0,
      width: '400px',
      color: 'rgba(255, 255, 255, 1)', // Cor para o progresso da música (branco)
      height: 10,
        '& .MuiSlider-thumb': {
          width: 10,
          height: 10,
          backgroundColor: 'rgba(255, 255, 255, 1)', // Cores do thumb
          borderRadius: '50%',
          transition: '0.3s cubic-bezier(.47,1.64,.41,.8)',
          '&::before': {
          boxShadow: '0 2px 12px 0 rgba(0,0,0,0.4)',
          },
          '&:hover, &.Mui-focusVisible': {
          boxShadow: `0px 0px 0px 8px ${'rgb(255 255 255 / 30%)'}`,
          },
          '&.Mui-active': {
          width: 20,
          height: 20,
          },
        },
        '& .MuiSlider-rail': {
          backgroundColor: 'rgba(255, 255, 255, 0.3)', // Cor da rail
          opacity: 0.5,
        },
      }}
    />
  );
}
