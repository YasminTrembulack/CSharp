import { Route, Routes } from "react-router-dom";
import UploadMusic from '../src/Pages/UploadMusic'
import MusicPlayer from "./Pages/MusicPlayer";
import UploadMusic2 from "./Pages/UploadMusic2";
import './App.css'
import Login from "./Pages/Login";
import Home from "./Pages/Home";

function App() {
 
  return (
    <>
      <Routes>
        <Route path='/' element={<Login/>} />
        <Route path='/home' element={<Home/>} />
        <Route path='/upload' element={<UploadMusic/>} />
        <Route path='/music/:id' element={<MusicPlayer/>} />
        <Route path='/up' element={<UploadMusic2/>} />
      </Routes>
    </>
  )
}

export default App
