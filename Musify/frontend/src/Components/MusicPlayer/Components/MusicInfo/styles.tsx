import styled, { keyframes } from 'styled-components';

// Defina a animação usando keyframes do Styled Components
const slideTop = keyframes`
  0% {
    transform: translateY(0);
  }
  100% {
    transform: translateY(-100px);
  }
`;

// Crie um componente estilizado que usa a animação
export const SlideTopDiv = styled.div`
  animation: ${slideTop} 0.3s ease-out both;
  background-color: #696969;
  width: 700px;
  height: 300px;
  z-index: 6;
`;