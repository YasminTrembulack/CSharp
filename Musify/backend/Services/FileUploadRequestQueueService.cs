using System.Threading.Channels;
using Microsoft.Extensions.Hosting;

namespace Musify.Services;

using Models;

public record FileUploadRequest(IFormFile File, UploadProcess Process);
public class FileUploadRequestQueueService
{
    public Channel<FileUploadRequest> Queue { get; private set; } 
        = Channel.CreateUnbounded<FileUploadRequest>();
}