import { useState, createContext, ReactNode } from 'react';
import IUser from '../Types/user';
import { jwtDecode } from 'jwt-decode';

interface IUserContext {
    curentUser: IUser | null;
    Logout: () => void;
    Login: (token: string) => void
}

export const UserContext = createContext({} as IUserContext);
UserContext.displayName = 'UserContext';

export const UserProvider = ({ children } : { children: ReactNode }) => {
    const [curentUser, setCurentUser] = useState<IUser | null>(null);
    
    function Login(token: string) {
        sessionStorage.setItem('@TOKEN', token);

        const jwtData = jwtDecode(token);
        console.log(jwtData.aud);
        console.log(jwtData.exp);
        console.log(jwtData.iat);
        console.log(jwtData.iss);
        console.log(jwtData.jti);
        console.log(jwtData.nbf);
        console.log(jwtData.sub);

        // const userData = {
        //     id: jwtData.
        // }
        
        // setCurentUser(user);
        // console.log("userContext: " + JSON.stringify(user));
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