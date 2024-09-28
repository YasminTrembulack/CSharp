import Avatar from "@mui/material/Avatar/Avatar";
import { UserContext } from "../../Context/UserContext";
import { useContext, useEffect } from "react";

export default function ProfileAvatar(){

  const { curentUser } = useContext(UserContext);

  useEffect(() => {
    console.log("User changed:", curentUser);
    // Aqui você pode adicionar qualquer lógica que precise ser executada
    // quando o usuário mudar, por exemplo, carregar mais dados.
  }, [curentUser]); // 


  function stringToColor(string: string) {
    let hash = 0;
    let i;
  
    /* eslint-disable no-bitwise */
    for (i = 0; i < string.length; i += 1) {
      hash = string.charCodeAt(i) + ((hash << 5) - hash);
    }
  
    let color = '#';
  
    for (i = 0; i < 3; i += 1) {
      const value = (hash >> (i * 8)) & 0xff;
      color += `00${value.toString(16)}`.slice(-2);
    }
    /* eslint-enable no-bitwise */
  
    return color;
  }
    
  function stringAvatar(name: string | undefined) {
    console.log("stringAvatar: " + JSON.stringify(curentUser));

    
    if (!name) {
      return {
        sx: {
          bgcolor: '#ccc', // Cor padrão se não houver nome
        },
        children: '?', // Usar um caractere de fallback
      };
    }
    try {
      return {
        sx: {
        bgcolor: stringToColor(name),
        },
        children: `${name.split(' ')[0][0]}${name.split(' ')[1][0]}`,
      };
    } catch (error) {
      return {
        sx: {
        bgcolor: stringToColor(name),
        },
        children: name[0].toUpperCase(),
      };
    }
  }

  return <Avatar {...stringAvatar(curentUser?.username)}/>
}