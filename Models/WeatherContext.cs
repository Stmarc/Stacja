using Microsoft.EntityFrameworkCore;

namespace WeatherAppMVC.Models
{
    public class WeatherContext : DbContext
    {
        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        {
        }

        public DbSet<WeatherData> WeatherData { get; set; }
    }
}
