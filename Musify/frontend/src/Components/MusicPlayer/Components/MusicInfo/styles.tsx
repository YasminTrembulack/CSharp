import styled, { keyframes } from 'styled-components';

// Defina a animação usando keyframes do Styled Components
const slideTop = keyframes`
  0% {
    transform: translateY(0);
  }
  100% {
    transform: translateY(-700px);
  }
`;

interface SlideTopDivProps {
  display?: string; 
}

// Crie um componente estilizado que usa a animação
export const SlideTopDiv = styled.div<SlideTopDivProps>`
  display: ${(props) => props.display};
  justify-content: center;
  position: absolute;
  animation: ${slideTop} 0.3s ease-out both;
  background-color: #696969;
  width: 700px;
  right: calc(50% + 300px) ;
  height: 700px;
  z-index: 2;
  bottom: 700;
`;