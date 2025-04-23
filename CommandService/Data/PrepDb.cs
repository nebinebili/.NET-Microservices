using CommandService.Models;
using CommandService.SyncDataServices.Grpc;

namespace CommandService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder applicationBuilder)
        {
            using(var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var grpcClient = serviceScope.ServiceProvider.GetService<IPlatformDataClient>();

                var platforms = grpcClient.ReturnAllPLatforms();

                SeedData(serviceScope.ServiceProvider.GetService<ICommandRepo>(),platforms);
            }
        }

        private static void SeedData(ICommandRepo repo,IEnumerable<Platform> platforms)
        {
            Console.WriteLine("Seeding new platforms....");

            foreach (var platform in platforms) 
            {
                if (!repo.ExternalPlatformExist(platform.ExternalID))
                {
                    repo.CreatePLatform(platform);
                }
                repo.SaveChanges();
            }
        }
    }
}
