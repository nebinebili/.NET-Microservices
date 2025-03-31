using CommandService.Models;
using Microsoft.EntityFrameworkCore;

namespace CommandService.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt): base(opt)
        {
            
        }

        public DbSet<Platform> Platforms { get; set; }

        public DbSet<Command> Commands { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           
            modelBuilder.Entity<Command>()
                .HasOne(c=>c.Platform)
                .WithMany(p=>p.Commands)
                .HasForeignKey(c=>c.PlatformId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
