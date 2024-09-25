import { Route, Routes } from "react-router-dom";
import UploadMusic from '../src/Pages/UploadMusic'
import MusicPlayer from "./Pages/MusicPlayer";
import UploadMusic2 from "./Pages/UploadMusic2";
import './App.css'

function App() {
 
  return (
    <>
      <Routes>
        <Route path='/' element={<UploadMusic/>} />
        <Route path='/music/:musicInfoId' element={<MusicPlayer/>} />
        <Route path='/up' element={<UploadMusic2/>} />
      </Routes>
    </>
  )
}

export default App
