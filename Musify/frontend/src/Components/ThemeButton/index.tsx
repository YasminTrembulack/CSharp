import { useEffect, useState } from "react";
import {LightMode, DarkMode} from '@mui/icons-material';
import { indigo } from '@mui/material/colors';

export default function ThemeButton(){
    const [theme, setTheme] = useState<string>('');

    useEffect(() => {
        const themeData = sessionStorage.getItem('@THEME');
        if (themeData) {
          setTheme(themeData);
        }
        else {
            sessionStorage.setItem('@THEME', 'Dark');
            setTheme('Dark');
        }
    }, []); 


    return  (
        <>
            {theme === 'Dark' 
                ? <DarkMode fontSize="large" sx={{ color: indigo[50] }} /> 
                : <LightMode fontSize="large" sx={{ color: indigo[50] }} />
            }
        </>
    )
}