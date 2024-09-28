import { FormContainer, Title, Forms, ImpuGroup, Forgot, BtnSign, Signup } from "./styles";
import { useNavigate } from "react-router-dom";
import { useContext, useState } from "react";
import { api } from "../../../../Service/api";
import { toast } from 'react-toastify';
import { UserContext } from "../../../../Context/UserContext";
import IUser from "../../../../Types/user";

export default function Form() {
  const [login, setLogin] = useState<string>('');
  const [password, setPass] = useState<string>('');
  const [loading, setLoading] = useState(false);
  const navigate = useNavigate();
  const { Login } = useContext(UserContext);

  async function handleSubmit(e: React.FormEvent<HTMLFormElement>) {
    e.preventDefault();
    setLoading(true);
    const payload = {
      username: login,
      password: password,
    };

    try {
      const response = await api.post('/auth/login', payload);
      const token = response.data.token;
    
      Login(token);
      navigate('/home');
      setLogin('');
      setPass(''); 
      toast.success('Logged in successfully');
      setLoading(false);
        
    } catch (err) {   
      toast.error("Username or Password don't match")
      console.log(err);
      setLoading(false);
    }
  }

  return (
      <FormContainer>
        <Title>Login</Title>
        <Forms onSubmit={handleSubmit}>
          <ImpuGroup >
            <label htmlFor="username">Username</label>
            <input onChange={(e) => setLogin(e.target.value)} type="text" name="username" id="username" placeholder="" />
          </ImpuGroup>
          <ImpuGroup>
            <label htmlFor="password">Password</label>
            <input onChange={(e) => setPass(e.target.value)} type="password" name="password" id="password" placeholder="" />
            <Forgot className="forgot">
              <a rel="noopener noreferrer" href="#"> Forgot Password ? </a>
            </Forgot>
          </ImpuGroup>
          <BtnSign type='submit' className="sign">Sign in</BtnSign>
        </Forms>
        <Signup className="">
          Don&apos;t have an account?
          <a rel="noopener noreferrer" href="#" className="">
            {loading ? 'Signing in...' : 'Sign in'}
          </a>
        </Signup>
      </FormContainer>
  );
};
