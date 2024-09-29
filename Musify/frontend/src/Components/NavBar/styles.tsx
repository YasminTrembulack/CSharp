import styled from "styled-components";


export const Header = styled.div` 
    /* background-color: #454545; */
    background-color: #0b0c19;
    height: 6vh;
`;

export const GradientLine = styled.div`
    background: linear-gradient(to left, #2eadff, #3d83ff,#7961ff, #8528ff);
    margin-bottom: 15px;
    height: 7px;
`;

export const HeaderContent = styled.div`
    display: flex;
    align-items: center;
    justify-content: space-between;
    padding: 0px 1%;
`;

export const RightContent = styled.div`
    width: 20%;
    display: flex;
    align-items: center;
    justify-content:right;
    gap: 3%;
`;

export const Title = styled.h1` 
    color: white;
    font-weight: 700;
    font-size: 40px;
`;
