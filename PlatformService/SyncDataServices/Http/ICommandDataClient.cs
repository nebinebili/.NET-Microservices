using PlatformService.DTOs;

namespace PlatformService.SyncDataServices.Http
{
    public interface ICommandDataClient
    {
        Task SendPlatformToCommand(PlatformReadDto platform);
    }
}
