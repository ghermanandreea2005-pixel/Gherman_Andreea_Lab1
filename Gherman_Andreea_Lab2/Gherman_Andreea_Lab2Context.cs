using Microsoft.EntityFrameworkCore;

public class Gherman_Andreea_Lab2Context(DbContextOptions<Gherman_Andreea_Lab2Context> options) : DbContext(options)
{
    public DbSet<Gherman_Andreea_Lab2.Models.Book> Book { get; set; } = default!;
    public DbSet<Gherman_Andreea_Lab2.Models.Publisher> Publisher { get; set; } = default!;
    public DbSet<Gherman_Andreea_Lab2.Models.Author> Author { get; set; } = default!;
}
