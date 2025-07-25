using APIcharacters.Models;
using Microsoft.EntityFrameworkCore;

namespace APIcharacters.Data;

public class AppDbContext : DbContext
{
    public DbSet<Character> Characters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = charactersInfo.sqlite"); 
        base.OnConfiguring(optionsBuilder);
    }
}