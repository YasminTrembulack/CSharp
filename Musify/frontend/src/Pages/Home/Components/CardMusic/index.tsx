import { Line, NotiBorderGlow, Notification, NotificationBody, NotificationBodyContent, NotificationContent, NotificationImage, NotificationTitle, NotiGlow } from "./styles";
import IMusic from "../../../../Types/music";

export default function CardMusic({ musicData } : { musicData : IMusic}){
  return (
    <Notification >
    <NotiBorderGlow />
    <NotiGlow />

    <NotificationImage src="play-button.png" alt="play-button.png" />
    <Line></Line>
    <NotificationContent>
      <NotificationTitle>{musicData.title}</NotificationTitle>
      <NotificationBody>{musicData.artist}</NotificationBody>
      <NotificationBodyContent style={{display: "flex"}}>
        <NotificationBody>{musicData.year}</NotificationBody>
        <NotificationBody>{musicData.duration}</NotificationBody>
      </NotificationBodyContent>
    </NotificationContent>
  </Notification>

  );
};
