import { Route, Routes } from "react-router-dom";
import UploadMusic from '../src/Pages/UploadMusic'
import MusicPlayer from "./Pages/MusicPlayer";
import './App.css'

function App() {
 
  return (
    <>
      <Routes>
        <Route path='/' element={<UploadMusic/>} />
        <Route path='/music/:id' element={<MusicPlayer/>} />
      </Routes>
    </>
  )
}

export default App
