using CommandService.Models;

namespace CommandService.Data
{
    public interface ICommandRepo
    {
        bool SaveChanges();

        //Platforms
        IEnumerable<Platform> GetAllPlatforms();
        void CreatePLatform(Platform platform);
        bool PlatformExits(int platformId);

        //Commands
        IEnumerable<Command> GetCommandsForPLatform(int platformId);
        Command GetCommand(int platformId,int commandId);
        void CreateCommand(int platformId, Command command);
    }
}
