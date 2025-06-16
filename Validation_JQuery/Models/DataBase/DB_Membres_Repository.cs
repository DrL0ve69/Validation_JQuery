namespace Validation_JQuery.Models.DataBase;

public class DB_Membres_Repository : IMembres_Repository
{
    public List<Membre> ListeMembres => DB_FakeSeeders.Seed_Membres;

    public void AjouterMembre(Membre membre)
    {
        ListeMembres.Add(membre);
    }

    public Membre GetMembre_Username(string username)
    {
        return ListeMembres.FirstOrDefault(m => m.Username.ToUpper() == username.ToUpper());
    }

    public void ModifierMembre(string username, Membre membre)
    {
        // Pouurait-t-on supprimer l'ancien membre et ajouter le nouveau ?
        /*
        ListeMembres.RemoveAll(m => m.Username.ToUpper() == username.ToUpper());
        ListeMembres.Add(membre);
        */

        Membre membreOG = GetMembre_Username(username);
        int index = ListeMembres.IndexOf(membreOG);
        if (index != -1)
        {
            ListeMembres[index] = membre;
        }
        else
        {
            throw new KeyNotFoundException($"Membre avec le nom d'utilisateur '{username}' non trouvé.");
        }
    }

    public void SupprimerMembre(string username)
    {
        ListeMembres.RemoveAll(m => m.Username.ToUpper() == username.ToUpper());
    }
}
