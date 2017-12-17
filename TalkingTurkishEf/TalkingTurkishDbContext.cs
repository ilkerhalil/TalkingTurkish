using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using TalkingTurkishEf.Entities;


namespace TalkingTurkishEf
{
    public class TalkingTurkishDbContext : DbContext
    {
        public TalkingTurkishDbContext(DbContextOptions<TalkingTurkishDbContext> options)
            : base(options)
        {

        }

        public DbSet<Language> Languages { get; set; }
        public DbSet<Thing> Things { get; set; }
        public DbSet<Voice> Voices { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    var configurationBuilder = new ConfigurationBuilder();
        //    var configuration = configurationBuilder.Build();

        //    string conString = configuration.GetConnectionString("Sqlite");
        //    optionsBuilder.UseSqlite(conString);
        //}
    }
    public class TalkingTurkishDbContextFactory : IDesignTimeDbContextFactory<TalkingTurkishDbContext>
    {
        public TalkingTurkishDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<TalkingTurkishDbContext>();
            optionsBuilder.UseSqlite("Data Source=TalkingTurkish.db");
            return new TalkingTurkishDbContext(optionsBuilder.Options);
        }
    }
}
