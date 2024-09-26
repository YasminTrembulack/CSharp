import { FormContainer, Title, Forms, ImpuGroup, Forgot, BtnSign, Signup } from "./styles";

export default function Form() {
  return (
      <FormContainer>
        <Title>Login</Title>
        <Forms>
          <ImpuGroup >
            <label htmlFor="username">Username</label>
            <input type="text" name="username" id="username" placeholder="" />
          </ImpuGroup>
          <ImpuGroup>
            <label htmlFor="password">Password</label>
            <input type="password" name="password" id="password" placeholder="" />
            <Forgot className="forgot">
              <a rel="noopener noreferrer" href="#"> Forgot Password ? </a>
            </Forgot>
          </ImpuGroup>
          <BtnSign className="sign">Sign in</BtnSign>
        </Forms>
        <Signup className="">
          Don&apos;t have an account?
          <a rel="noopener noreferrer" href="#" className="">
            Sign up
          </a>
        </Signup>
      </FormContainer>
  );
};
