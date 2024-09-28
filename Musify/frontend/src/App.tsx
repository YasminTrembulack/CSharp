import { Route, Routes } from "react-router-dom";
import UploadMusic from '../src/Pages/UploadMusic'
import MusicPlayer from "./Pages/MusicPlayer";
import UploadMusic2 from "./Pages/UploadMusic2";
import './App.css'
import Login from "./Pages/Login";
import Home from "./Pages/Home";
import { ToastContainer } from 'react-toastify';
import '../src/Styles/toaststyles.css';

import 'react-toastify/dist/ReactToastify.css';
import { MusicProvider } from "./Context/MusicContext";
import { UserContext, UserProvider } from "./Context/UserContext";
import { useContext } from "react";
import NavBar from "./Components/NavBar";

function App() {
 
  const { curentUser } = useContext(UserContext);
  return (
    <UserProvider>
    <MusicProvider> 
      {curentUser !== null && <NavBar/>}
      <Routes>
        <Route path='/' element={<Login/>} />
        <Route path='/home' element={<Home/>} />
        <Route path='/upload' element={<UploadMusic/>} />
        <Route path='/music/:id' element={<MusicPlayer/>} />
        <Route path='/up' element={<UploadMusic2/>} />
      </Routes>
      <ToastContainer
        position="top-right"
        autoClose={4000}
        hideProgressBar={false}
        newestOnTop={false}
        closeOnClick
        rtl={false}
        pauseOnFocusLoss
        draggable
        pauseOnHover
        theme="dark"
      />
    </MusicProvider>
    </UserProvider>
  )
}

export default App
