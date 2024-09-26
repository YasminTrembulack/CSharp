import { NotiBorderGlow, Notification, NotificationBody, NotificationImage, NotificationTitle, NotiGlow } from "./styles";

interface User {
    id: string;
    username: string;
    email: string;
}

interface MusicHeader {
    id: string;
    name: string;
    description: string;
}

interface Music {
    title: string;
    artist: string;
    duration: string; // formato: "MM:SS"
    year: number;
    lyrics: string;
    album: string;
    user: User;
    musicHeaderId: string;
    musicHeader: MusicHeader;
}


export default function CardMusic({ musicData } : { musicData : Music}){
  return (
    <Notification>
    <NotiBorderGlow />
    <NotiGlow />
    <NotificationImage src="" alt={`${musicData.title} Cover`} />
    <div style={{zIndex: 8}}>
      <NotificationTitle>{musicData.title}</NotificationTitle>
      <NotificationBody>{musicData.artist}</NotificationBody>
    </div>
  </Notification>

  );
};
