using Microsoft.EntityFrameworkCore;

namespace DotNet6_WebAPI_Demo.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
    }
    public DbSet<SuperHero> SuperHeroes { get; set; }
}
