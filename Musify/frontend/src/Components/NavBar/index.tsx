import ProfileAvatar from "../ProfileAvatar";
import SelectLanguage from "../SelectLanguage";
import ThemeButton from "../ThemeButton";
import { Header, GradientLine, HeaderContent, Title, RightContent } from "./styles";


export default function NavBar(){

    return(
        <Header>
            <GradientLine/>
            <HeaderContent>
                <Title>Musify</Title>
                <RightContent>
                    <ThemeButton/>
                    <SelectLanguage/>
                    <ProfileAvatar/>
                </RightContent>
            </HeaderContent>
        </Header>
    )
}

