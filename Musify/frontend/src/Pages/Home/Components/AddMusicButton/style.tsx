import styled from "styled-components";

export const FormContainer = styled.div`
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -50%);
    width: 320px;
    border-radius: 0.75rem;
    background-color: rgba(17, 24, 39, 1);
    padding: 2rem;
    color: rgba(243, 244, 246, 1);
`;

export const Title = styled.p`
    text-align: center;
    font-size: 1.5rem;
    line-height: 2rem;
    font-weight: 700;
`;

export const Forms = styled.form`
    margin-top: 1.5rem;
`;

export const ImpuGroup = styled.div`
    margin-top: 0.25rem;
    font-size: 0.875rem;
    line-height: 1.25rem;

    & label {
        display: block;
        color: rgba(156, 163, 175, 1);
        margin-bottom: 4px;
    }

    & input, textarea {
        width: 100%;
        border-radius: 0.375rem;
        border: 1px solid rgba(55, 65, 81, 1);
        outline: 0;
        background-color: rgba(17, 24, 39, 1);
        padding: 0.75rem 1rem;
        color: rgba(243, 244, 246, 1);
        resize: none;
    }

    & input:focus, textarea:focus {
        border-color: rgba(167, 139, 250);
    }
`;


export const BtnSign = styled.button`
    display: block;
    width: 100%;
    background-color: rgba(167, 139, 250, 1);
    padding: 0.75rem;
    text-align: center;
    color: rgba(17, 24, 39, 1);
    border: none;
    border-radius: 0.375rem;
    font-weight: 600;
    margin-top: 20px;

    &:hover {
        background-color: #9875ff;
    }
`;

