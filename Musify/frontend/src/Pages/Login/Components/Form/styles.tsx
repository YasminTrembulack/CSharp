import styled from "styled-components";

export const FormContainer = styled.div`
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
    margin-bottom: 20px;
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

    & input {
        width: 100%;
        border-radius: 0.375rem;
        border: 1px solid rgba(55, 65, 81, 1);
        outline: 0;
        background-color: rgba(17, 24, 39, 1);
        padding: 0.75rem 1rem;
        color: rgba(243, 244, 246, 1);
    }

    & input:focus {
        border-color: rgba(167, 139, 250);
    }
`;

export const Forgot = styled.div`
    display: flex;
    justify-content: flex-end;
    font-size: 0.75rem;
    line-height: 1rem;
    color: rgba(156, 163, 175,1);
    margin: 8px 0 14px 0;
    
    & a {
        color: rgba(243, 244, 246, 1);
        text-decoration: none;
        font-size: 14px;
    }

    & a:hover {
        text-decoration: underline rgba(167, 139, 250, 1);
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

    &:hover {
        background-color: #9875ff;
    }
`;


export const Signup = styled.div`
    font-size: 0.75rem;
    line-height: 1rem;
    color: rgba(156, 163, 175, 1);
    display: flex;
    align-items: center;
    justify-content: center;
    gap: 5px;

    & a:hover {
        text-decoration: underline rgba(167, 139, 250, 1);
    }
    & a {
        color: rgba(243, 244, 246, 1);
        text-decoration: none;
        font-size: 14px;
    }
`;

