namespace Musify.Models;

public class UploadProcess
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public int LoadingBar { get; set; } = 0;
    public string Status { get; set; } = "Loading...";
    public bool Finished { get; set; } = false;
    public Guid? MusicHeader { get; set; } = null;
}