import { useContext } from "react";
import { SlideTopDiv } from "./styles";
import { MusicContext } from "../../../../Context/MusicContext";
import MusicProgressLine from "../../../MusicProgressLine";

export default function MusicInfo({display}: { display :string}) {

  const { currentMusic } =  useContext(MusicContext);

    return (
      <SlideTopDiv display={display}>
        <h1>{currentMusic?.title}</h1>
        <MusicProgressLine></MusicProgressLine>
      </SlideTopDiv>
    );
  };