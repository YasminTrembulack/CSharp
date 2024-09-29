import { useState, createContext, ReactNode, useEffect } from 'react';
import IUser from '../Types/user';
import { jwtDecode } from 'jwt-decode';

interface IUserContext {
    currentUser: IUser | null;
    userLogout: () => void;
    Login: (token: string) => void
}

export const UserContext = createContext({} as IUserContext);
UserContext.displayName = 'UserContext';

export const UserProvider = ({ children } : { children: ReactNode }) => {
    const [currentUser, setCurrentUser] = useState<IUser | null>(null);
    
    useEffect(() => {
        const token = sessionStorage.getItem('@TOKEN');
        if (token) {
          try {
            const decodedUser = jwtDecode<IUser>(token);
            setCurrentUser(decodedUser);
          } catch (error) {
            console.error("Erro ao decodificar o token: ", error);
            userLogout();
          }
        }
    }, []); 

    function Login(token: string) {
        sessionStorage.setItem('@TOKEN', token);
        const decodedUser = jwtDecode<IUser>(token);
        setCurrentUser(decodedUser);
    }

    function userLogout() {
        sessionStorage.removeItem('@TOKEN');
        setCurrentUser(null);
    }
   
    return (
        <UserContext.Provider
            value={{
                currentUser,
                Login,
                userLogout
            }}
        >
            {children}
        </UserContext.Provider>
    )
}