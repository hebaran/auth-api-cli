using AuthApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthApi.Data;

public class UserDbContext : DbContext
{
    public DbSet<UserModel> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=users.sqlite");
        base.OnConfiguring(optionsBuilder);
    }
}
