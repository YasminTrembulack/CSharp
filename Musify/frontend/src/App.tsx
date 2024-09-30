import { Route, Routes, useLocation } from "react-router-dom";
import UploadMusic from '../src/Pages/UploadMusic'
import MusicPlayer from "./Components/MusicPlayer";
import UploadMusic2 from "./Pages/UploadMusic2";
import './App.css'
import Login from "./Pages/Login";
import Home from "./Pages/Home";
import { ToastContainer } from 'react-toastify';
import '../src/Styles/toaststyles.css';

import 'react-toastify/dist/ReactToastify.css';
import { MusicProvider } from "./Context/MusicContext";
import { UserProvider } from "./Context/UserContext";
import NavBar from "./Components/NavBar";

function App() {
 
  const location = useLocation(); 
  const isLoginPage = location.pathname === '/';
  
  return (
    <UserProvider>
    <MusicProvider> 
      {!isLoginPage && <NavBar/>}
      <Routes>
        <Route path='/' element={<Login/>} />
        <Route path='/home' element={<Home/>} />
        <Route path='/upload' element={<UploadMusic/>} />
        <Route path='/music/:id' element={<MusicPlayer/>} />
        <Route path='/up' element={<UploadMusic2/>} />
      </Routes>
       <MusicPlayer/>
      <ToastContainer
        position="top-right"
        autoClose={3000}
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
