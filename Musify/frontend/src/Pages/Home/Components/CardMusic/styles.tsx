import styled from 'styled-components';

export const Note = styled.div`
  color: var(--color);
  position: fixed;
  top: 80%;
  left: 50%;
  transform: translateX(-50%);
  text-align: center;
  font-size: 0.9rem;
  width: 75%;
`;



export const Notification = styled.div`
  display: flex;
  flex-direction: row;
  justify-content: end;
  align-items: center;
  isolation: isolate;
  position: relative;
  width: 20rem;
  height: 6.8rem;
  background: rgba(17, 24, 39, 1);
  border-radius: 1rem;
  overflow: hidden;
  font-family: 'Gill Sans', 'Gill Sans MT', Calibri, 'Trebuchet MS', sans-serif;
  font-size: 16px;
  --gradient: linear-gradient(to bottom, #2eadff, #3d83ff, #7e61ff);
  --color: #32a6ff;

  &:before {
    position: absolute;
    content: "";
    inset: 0.0625rem;
    border-radius: 0.9375rem;
    background: rgba(17, 24, 39, 1);
    z-index: 2;
  }

  &:after {
    position: absolute;
    content: "";
    width: 0.25rem;
    inset: 0.65rem auto 0.65rem 0.5rem;
    border-radius: 0.125rem;
    background: var(--gradient);
    transition: transform 300ms ease;
    z-index: 4;
  }

  &:hover:after {
    transform: translateX(0.15rem);
  }
`;


export const NotificationContent = styled.div`
  display: flex;
  flex-direction: column;
  align-items: start;
  justify-content: center;
  height: 6rem;
  width: 14rem;
`;

export const NotificationBodyContent = styled.div`
  display: flex;
  align-items: start;
  justify-content: space-between;
  width: 14rem;
`;

export const NotificationImage = styled.img`
  width: 3rem;  // Ajuste o tamanho conforme necessário
  height: 3rem; // Ajuste o tamanho conforme necessário
  border-radius: 50%; // Se você quiser que a imagem seja redonda
  margin-right: 1rem; // Espaçamento entre a imagem e o texto
  z-index: 4;
  transition: transform 300ms ease;


  ${Notification}:hover & {
    transform: translateX(0.15rem);
  }
`;

export const Line = styled.div`
  width: 1px;  // Ajuste o tamanho conforme necessário
  height: 4.5rem; // Ajuste o tamanho conforme necessário
  z-index: 4;
  transition: transform 300ms ease;
  background-color: #242b3b;

  ${Notification}:hover & {
    transform: translateX(0.15rem);
  }
`;

export const NotificationTitle = styled.div`
  color: var(--color);
  padding: 0rem 0.25rem 0.4rem 1.25rem;
  font-weight: 500;
  font-size: 1.1rem;
  transition: transform 300ms ease;
  z-index: 5;

  ${Notification}:hover & {
    transform: translateX(0.15rem);
  }
`;

export const NotificationBody = styled.div`
  color: #99999d;
  padding: 0 1.25rem;
  transition: transform 300ms ease;
  z-index: 5;

  ${Notification}:hover & {
    transform: translateX(0.25rem);
  }
`;

export const NotiGlow = styled.div`
  position: absolute;
  width: 20rem;
  height: 20rem;
  transform: translate(-50%, -50%);
  background: radial-gradient(circle closest-side at center, white, transparent);
  opacity: 0;
  transition: opacity 300ms ease;
  z-index: 3;

  ${Notification}:hover & {
    opacity: 0.1;
  }
`;

export const NotiBorderGlow = styled.div`
  position: absolute;
  width: 20rem;
  height: 20rem;
  transform: translate(-50%, -50%);
  background: radial-gradient(circle closest-side at center, white, transparent);
  opacity: 0;
  transition: opacity 300ms ease;
  z-index: 1;

  ${Notification}:hover & {
    opacity: 0.1;
  }
`;
