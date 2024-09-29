import { UserContext } from "../../Context/UserContext";
import { useContext } from "react";
import { Avatar, ListItemIcon, Menu, MenuItem } from "@mui/material";
import PersonIcon from '@mui/icons-material/Person';
import React from "react";
import { Logout } from "@mui/icons-material";

export default function ProfileAvatar(){

  const { currentUser, userLogout } = useContext(UserContext);
  const [anchorEl, setAnchorEl] = React.useState<null | HTMLElement>(null);
  
  const open = Boolean(anchorEl);

  const handleClick = (event: React.MouseEvent<HTMLDivElement>) => {
    setAnchorEl(event.currentTarget);
  };

  const handleClose = () => {
    setAnchorEl(null);
  };

  const handleLogout = () => {
    setAnchorEl(null);
    userLogout();
  };

  function stringToColor(string: string) {
    let hash = 0;
    let i;
  
    for (i = 0; i < string.length; i += 1) {
      hash = string.charCodeAt(i) + ((hash << 5) - hash);
    }
  
    let color = '#';
  
    for (i = 0; i < 3; i += 1) {
      const value = (hash >> (i * 8)) & 0xff;
      color += `00${value.toString(16)}`.slice(-2);
    }
    
    return color;
  }
    
  function stringAvatar(name: string | undefined) {
    console.log("stringAvatar: " + JSON.stringify(currentUser));
    
    if (!name) {
      return {
        sx: {
          bgcolor: '#ccc', // Cor padrão se não houver nome
        },
        children: '?', // Usar um caractere de fallback
      };
    }

    return {
      sx: {
      bgcolor: stringToColor(name),
      },
      children: name.includes(' ') ? `${name.split(' ')[0][0]}${name.split(' ')[1][0]}` : name[0].toUpperCase(),
    };
  }

  return(
    <>
      <Avatar onClick={handleClick} {...stringAvatar(currentUser?.Username)}/>
      <Menu
        sx={{
          '& .MuiPaper-root': {
            backgroundColor: '#111827', // Muda a cor de fundo
            color: 'white',             // Muda a cor do texto
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
        <MenuItem onClick={handleClose}>
          <ListItemIcon>
            <PersonIcon color="secondary" fontSize="small" />
          </ListItemIcon>
          Profile
        </MenuItem>
        <MenuItem onClick={handleLogout}>
          <ListItemIcon>
            <Logout color="secondary" fontSize="small" />
          </ListItemIcon>
          Logout
        </MenuItem>
      </Menu>
    </>
  ) 
}