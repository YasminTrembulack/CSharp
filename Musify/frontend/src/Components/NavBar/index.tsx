import ProfileAvatar from "../ProfileAvatar";
import { Header, GradientLine, HeaderContent } from "./styles";


export default function NavBar(){

    return(
        <Header>
            <GradientLine/>
            <HeaderContent>
                <ProfileAvatar/>
            </HeaderContent>
        </Header>
    )
}

