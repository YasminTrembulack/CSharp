import styled from "styled-components";

export const MainContainer = styled.div`
    display: flex;
    align-items: center;
    justify-content: center;
    height: 94vh;
    background-color:#0b0c19 ;
`;

export const MusicsContainer = styled.div`
    display: grid;
    grid-template-columns: repeat(auto-fill, minmax(17rem, 1fr));
    grid-template-rows: repeat(auto-fill, minmax(100px, 1fr));
    
    height: 94vh;
    width: 80%;
    gap: 20px;
    padding: 50px;
`;

export const AsideRight = styled.div`
    display: flex;
    justify-content: right;
    align-items:end;
    height: 94vh;
    width: 10%;
    padding: 30px;
`;

export const AsideLeft = styled.div`
    display: flex;
    justify-content: center;
    align-items:end;
    height: 94vh;
    width: 10%;
`;