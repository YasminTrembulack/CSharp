const source = "http://localhost:5036/music/63FDCD59-318D-47E9-672C-08DCD998FF32";

window.onload = function()
{
    const video = document.getElementsByTagName('hls-video')[0];
    video.src = source;
};