using CommandService.Models;
using System;

namespace CommandService.Data
{
    public class CommandRepo : ICommandRepo
    {
        private readonly AppDbContext _dbContext;

        public CommandRepo(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateCommand(int platformId, Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));

            }
            command.PlatformId = platformId;
            _dbContext.Commands.Add(command);
        }

        public void CreatePLatform(Platform platform)
        {
            if (platform == null) 
            {
                throw new ArgumentNullException(nameof(platform));
            }
             _dbContext.Platforms.Add(platform);
        }

        public bool ExternalPlatformExist(int externalPlatformId)
        {
            return _dbContext.Platforms.Any(p => p.ExternalID == externalPlatformId);
        }

        public IEnumerable<Platform> GetAllPlatforms()
        {
            return _dbContext.Platforms.ToList();
        }

        public Command GetCommand(int platformId, int commandId)
        {
            return _dbContext.Commands.FirstOrDefault(c => c.Id == commandId && c.PlatformId == platformId);
        }

        public IEnumerable<Command> GetCommandsForPLatform(int platformId)
        {
            return _dbContext.Commands.Where(c=>c.PlatformId == platformId).OrderBy(c=>c.Platform.Name);
        }

        public bool PlatformExits(int platformId)
        {
            return _dbContext.Platforms.Any(p=>p.Id == platformId);
        }

        public bool SaveChanges()
        {
            return _dbContext.SaveChanges()>=0;
        }
    }
}
