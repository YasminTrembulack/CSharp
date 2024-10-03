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




export const StyledWrapper = styled.div`
  .card {
  width: 190px;
  height: 254px;
  background: lightgrey;
  border-radius: 10px;
}

.card .one {
  width: 190px;
  height: 254px;
  z-index: 10;
  position: absolute;
  background: rgba(255, 255, 255, 0.55);
  box-shadow: 0 8px 32px 0 rgba(31, 38, 135, 0.37);
  backdrop-filter: blur(8.5px);
  -webkit-backdrop-filter: blur(8.5px);
  border-radius: 10px;
  border: 1px solid rgba(255, 255, 255, 0.18);
}

.card .one .title {
  width: 70px;
  border: 1px solid rgba(180, 177, 177, 0.308);
  display: block;
  margin: 12px auto;
  text-align: center;
  font-size: 10px;
  border-radius: 12px;
  font-family: Roboto, sans-serif;
  color: rgba(102, 100, 100, 0.911);
}

.card .one .music {
  width: 80px;
  height: 80px;
  background: rgba(216, 212, 212, 0.726);
  margin: 30px auto;
  border-radius: 15px;
  display: flex;
  align-items: center;
  justify-content: center;
}

.card .one .name {
  width: 150px;
  height: 20px;
  font-size: 12px;
  font-weight: 500;
  font-family: Roboto, sans-serif;
  padding: 0 5px;
  margin: -22px auto;
  display: block;
  overflow: hidden;
  text-align: center;
  color: rgba(50, 49, 51, 0.637);
}
.card .one .name1 {
  width: 120px;
  height: 20px;
  font-size: 9px;
  font-weight: 500;
  font-family: Roboto, sans-serif;
  padding: 0 5px;
  margin: 19px auto;
  display: block;
  overflow: hidden;
  text-align: center;
  color: rgba(50, 49, 51, 0.637);
}
.card .one .bar {
  width: 100px;
  margin: -15px auto;
  display: flex;
  align-items: center;
  justify-content: space-between;
  padding: 0 5px;
  cursor: pointer;
}

.card .one .bar:last-child {
  margin: 35px auto;
  width: 100%;
  padding: 2px 23px;
}
.card .one .bar .color {
  fill: rgba(82, 79, 79, 0.829);
}
.card .one .bar .color1 {
  fill: rgba(29, 28, 28, 0.829);
  cursor: pointer;
}

.card .one .bar .bi:first-child {
  transform: rotate(180deg);
}
.card .one .bar:last-child .color1:first-child {
  transform: rotate(0deg);
}

.card .two {
  width: 60px;
  height: 60px;
  background-color: rgb(131, 25, 163);
  filter: drop-shadow(0 0 10px rgb(131, 25, 163));
  border-radius: 50%;
  position: relative;
  top: 30px;
  left: 20px;
  animation: one 5s infinite;
}

.card .three {
  width: 60px;
  height: 60px;
  background-color: rgb(29, 209, 149);
  filter: drop-shadow(0 0 10px rgb(29, 209, 149));
  border-radius: 50%;
  position: relative;
  top: 90px;
  left: 90px;
  animation: two 5s infinite;
}

@keyframes one {
  0% {
    top: 30px;
    left: 20px;
  }
  20% {
    top: 50px;
    left: 40px;
  }
  40% {
    top: 80px;
    left: 70px;
  }
  50% {
    top: 60px;
    left: 40px;
  }
  60% {
    top: 35px;
    left: 90px;
  }
  80% {
    top: 70px;
    left: 70px;
  }
  100% {
    top: 30px;
    left: 20px;
  }
}

@keyframes two {
  0% {
    top: 90px;
    left: 90px;
  }
  20% {
    top: 50px;
    left: 40px;
  }
  40% {
    top: 60px;
    left: 20px;
  }
  50% {
    top: 80px;
    left: 30px;
  }
  60% {
    top: 35px;
    left: 90px;
  }
  80% {
    top: 70px;
    left: 60px;
  }
  100% {
    top: 90px;
    left: 90px;
  }
}

`;