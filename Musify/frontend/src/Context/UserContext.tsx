import { useState, createContext, ReactNode } from 'react';
import IUser from '../Types/user';

interface IUserContext {
    curentUser: IUser | null;
    Logout: () => void;
    Login: (user: IUser, token: string) => void
}

export const UserContext = createContext({} as IUserContext);
UserContext.displayName = 'UserContext';

export const UserProvider = ({ children } : { children: ReactNode }) => {
    const [curentUser, setCurentUser] = useState<IUser | null>(null);
    
    function Login(user: IUser, token: string) {
        sessionStorage.setItem('@TOKEN', token);
        setCurentUser(user);
    }

    function Logout() {
        sessionStorage.clear();
        setCurentUser(null);
    }
   
    return (
        <UserContext.Provider
            value={{
                curentUser,
                Login,
                Logout
            }}
        >
            {children}
        </UserContext.Provider>
    )
}