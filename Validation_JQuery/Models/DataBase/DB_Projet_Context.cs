using Microsoft.EntityFrameworkCore;

namespace Validation_JQuery.Models.DataBase;

public class DB_Projet_Context : DbContext
{
    public DB_Projet_Context(DbContextOptions<DB_Projet_Context> options) : base(options) { }
    public DbSet<Membre> Membres { get; set; }
    /*
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Membre>().HasData(DB_Seeders.Seed_Membres);
        base.OnModelCreating(modelBuilder);
    }
    */
}
