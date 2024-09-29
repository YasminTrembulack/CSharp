import { useState } from "react";
import { ListItemIcon, Menu, MenuItem } from "@mui/material";
import { Image } from "./style";

export default function SelectLanguage(){

  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);
  const [language, setLanguage] = useState<string>(() => {
    return sessionStorage.getItem('@LANGUAGE') || 'Pt-Br';
  });
  
  const open = Boolean(anchorEl);

  const handleClick = (event: React.MouseEvent<HTMLDivElement>) => {
    setAnchorEl(event.currentTarget);
  };


  const handleChangeLanguage = (lang: string) => {
    setLanguage(lang); // Atualiza o estado com a linguagem selecionada
    sessionStorage.setItem('@LANGUAGE', lang); // Salva o idioma selecionado no sessionStorage
    setAnchorEl(null); // Fecha o menu
  };

  const handleClose = () => {
    setAnchorEl(null);
  };


  return(
    <>
        <Image src={`icon-${language}.png`} onClick={handleClick} />
        <Menu
            anchorOrigin={{
                vertical: 'bottom',
                horizontal: 'right',
            }}
            transformOrigin={{
                vertical: 'top',
                horizontal: 'right',
            }}
            sx={{
            '& .MuiPaper-root': {
                backgroundColor: '#111827', // Muda a cor de fundo
                color: 'white',
                marginTop: '5px'            // Muda a cor do texto
            },
            }}
            id="basic-menu"
            anchorEl={anchorEl}
            open={open}
            onClose={handleClose}
            MenuListProps={{
                'aria-labelledby': 'basic-button',
            }}
        >
            { language !== 'Pt-Br' &&
                <MenuItem style={{gap: "10px"}} onClick={() => handleChangeLanguage('Pt-Br')}>
                    <ListItemIcon>
                        <Image src="icon-Pt-Br.png" alt="Brazil flag" />
                    </ListItemIcon>
                    Pt
                </MenuItem>
            }
            { language !== 'En' &&
                <MenuItem style={{gap: "10px"}} onClick={() => handleChangeLanguage('En')}>
                    <ListItemIcon>
                        <Image src="icon-En.png" alt="USA flag" />
                    </ListItemIcon>
                    En
                </MenuItem>
            }
            { language !== 'Jp' &&
                <MenuItem style={{gap: "10px"}} onClick={() => handleChangeLanguage('Jp')}>
                    <ListItemIcon>
                        <Image src="icon-Jp.png" alt="Japan flag" />
                    </ListItemIcon>
                    Jp
                </MenuItem>
            }
        </Menu>
    </>
  ) 
}