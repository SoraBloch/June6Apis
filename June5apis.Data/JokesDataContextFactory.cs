using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace June5apis.Data
{
    public class JokesDataContextFactory : IDesignTimeDbContextFactory<JokesDataContext>
    {
        public JokesDataContext CreateDbContext(string[] args)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), $"..{Path.DirectorySeparatorChar}June6apis.Web"))
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.local.json", optional: true, reloadOnChange: true).Build();

            return new JokesDataContext(config.GetConnectionString("ConStr"));
        }
    }
}