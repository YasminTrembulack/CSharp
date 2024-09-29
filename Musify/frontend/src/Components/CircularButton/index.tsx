import { Fab } from "@mui/material";
import { ReactNode } from "react";

interface CircularButtonProps {
    children?: ReactNode;
    onClick?: () => void; 
}

export default function CircularButton({ children, onClick }: CircularButtonProps){

  return(
    <>
        <Fab color="secondary" aria-label="add" onClick={onClick}>
            {children ? children : <></>}
        </Fab>
        
    </>
  ) 
}