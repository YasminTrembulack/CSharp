import styled from 'styled-components'

export const Music = styled.video`
    display: none;
    width: 500px;
    height: 50px;
    background-color: rgba(17, 24, 39, 1);
`;

export const ContainerBar = styled.div`
    z-index: 1;
    position: absolute;
    bottom: 0px;
    right: calc(50% + 300px) ;
    width: 700px;
    height: 50px;
    color: white;
    display: flex;
    justify-content: space-evenly;
    align-items: center;
    background-color: #333333
`;
