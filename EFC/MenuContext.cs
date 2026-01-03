using EFC.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFC;

public class MenuContext : DbContext
{
    public DbSet<Drink> Drinks { get; set; }
    public DbSet<DrinksMenu> DrinksMenus { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string projectRoot = Directory.GetCurrentDirectory();
        string dbPath = Path.Combine(projectRoot, "menu.db");
        
        optionsBuilder.UseSqlite($"Data Source={dbPath}");
        Console.WriteLine($"Database at: {dbPath}");
    }
}