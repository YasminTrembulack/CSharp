using System.Threading.Channels;
using Microsoft.Extensions.Hosting;

namespace Musify.Services;

using Models;

public record FileUploadRequest(string TempFolder, UploadProcess Process, Guid MusicInfoId);
public class FileUploadRequestQueueService
{
    public Channel<FileUploadRequest> Queue { get; private set; } 
        = Channel.CreateUnbounded<FileUploadRequest>();
}