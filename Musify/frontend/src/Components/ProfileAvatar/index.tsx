import { UserContext } from "../../Context/UserContext";
import React, { useContext, useState } from "react";
import { Avatar, ListItemIcon, Menu, MenuItem, Skeleton } from "@mui/material";
import PersonIcon from '@mui/icons-material/Person';
import { Logout } from "@mui/icons-material";
import { indigo } from "@mui/material/colors";
import { useNavigate } from "react-router-dom";
import { MusicContext } from "../../Context/MusicContext";

export default function ProfileAvatar(){

  const { currentUser, userLogout } = useContext(UserContext);
  const { ClosePlayer } = useContext(MusicContext);
  const [anchorEl, setAnchorEl] = useState<null | HTMLElement>(null);

  const navigate = useNavigate();
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
    navigate('/');
    ClosePlayer();
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
    
  function stringAvatar(name: string ) {
    return {
      sx: {
        bgcolor: stringToColor(name),
      },
        children: name.includes(' ') ? `${name.split(' ')[0][0]}${name.split(' ')[1][0]}` : name[0].toUpperCase(),
    };
  }

  return(
    <>
      {currentUser 
      ? <Avatar onClick={handleClick} {...stringAvatar(currentUser.FullName)}/>
      : <Skeleton sx={{ bgcolor: 'grey.500' }} variant="circular" width={40} height={40} />
      }
      <Menu
        sx={{
          '& .MuiPaper-root': {
            backgroundColor: '#111827', // Muda a cor de fundo
            color: 'white',
            marginTop: '10px'            // Muda a cor do texto
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
            <PersonIcon  sx={{ color: indigo[50] }} fontSize="small" />
          </ListItemIcon>
          Profile
        </MenuItem>
        <MenuItem onClick={handleLogout}>
          <ListItemIcon>
            <Logout  sx={{ color: indigo[50] }} fontSize="small" />
          </ListItemIcon>
          Logout
        </MenuItem>
      </Menu>
    </>
  ) 
}