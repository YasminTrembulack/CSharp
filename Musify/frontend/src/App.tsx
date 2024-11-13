import { Route, Routes, useLocation } from "react-router-dom";
// import UploadMusic from '../src/Pages/UploadMusic';
import MusicPlayer from "./Components/MusicPlayer";
import UploadMusic2 from "./Pages/UploadMusic2";
import './App.css';
import Login from "./Pages/Login";
import Home from "./Pages/Home";
import { ToastContainer } from 'react-toastify';
import '../src/Styles/toaststyles.css';

import 'react-toastify/dist/ReactToastify.css';
import { MusicContext, MusicProvider } from "./Context/MusicContext"; // Removi o useContext daqui
import { UserProvider } from "./Context/UserContext";
import NavBar from "./Components/NavBar";
import { useContext } from "react";
import UploadVideo from "./Pages/UploadVideo";
import VideoPlayer from "./Pages/VideoPlayer";

function App() {
  const location = useLocation(); 
  const isLoginPage = location.pathname === '/';

  return (
    <UserProvider>
      <MusicProvider> 
        {!isLoginPage && <NavBar />}
        <Routes>
          <Route path='/' element={<Login />} />
          <Route path='/home' element={<Home />} />
          <Route path='/upload' element={<UploadVideo />} />
          <Route path='/music/:id' element={<MusicPlayer />} />
          <Route path='/video/:id' element={<VideoPlayer />} />
          <Route path='/up' element={<UploadMusic2 />} />
        </Routes>
        <MusicPlayerWrapper /> {/* MusicPlayer agora renderizado corretamente */}
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
  );
}

// Componente separado para gerenciar o MusicPlayer
function MusicPlayerWrapper() {
  const { currentMusic } = useContext(MusicContext); // useContext agora dentro do MusicProvider

  // Mostra o MusicPlayer se currentMusic não for null
  if (currentMusic) {
    return <MusicPlayer />;
  }

  return null; // Retorna null se não tiver música
}

export default App;
