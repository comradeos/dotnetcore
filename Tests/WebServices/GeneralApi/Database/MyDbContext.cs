using Microsoft.EntityFrameworkCore;
using GeneralApi.Models;

namespace GeneralApi.Database;

public class MyDbContext : DbContext
{
    public MyDbContext(DbContextOptions<MyDbContext> options):base(options){}

    public DbSet<MyData> MyData { get; set; }
}