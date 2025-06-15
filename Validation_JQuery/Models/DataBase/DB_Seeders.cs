namespace Validation_JQuery.Models.DataBase;

public static class DB_Seeders
{
    public static List<Membre> Seed_Membres { get; set; } = new List<Membre>()
    {
        new Membre
        {
            Nom = "Dupont",
            Prenom = "Jean",
            Email = "TitJean@gmail.com",
            Username = "TitJean99",
            DateNaissance = new DateOnly(1999, 1, 1),

        },
                new Membre
        {
            Nom = "Doe",
            Prenom = "John",
            Email = "DoeDoeJ@gmail.com",
            Username = "GuessTheDoe",
            DateNaissance = new DateOnly(1969, 10, 10),

        },

    };
    public static void Seed(IApplicationBuilder appBuilder)
    {
        DB_Projet_Context context = appBuilder.ApplicationServices.CreateScope()
            .ServiceProvider.GetRequiredService<DB_Projet_Context>();
        if (!context.Membres.Any())
        {
            context.Membres.AddRange(Seed_Membres);
            context.SaveChanges();
        }
    }
}
