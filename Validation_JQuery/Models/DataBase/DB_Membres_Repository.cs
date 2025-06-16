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
        throw new NotImplementedException();
    }

    public void ModifierMembre(Membre membre)
    {
        throw new NotImplementedException();
    }

    public void SupprimerMembre(string username)
    {
        throw new NotImplementedException();
    }
}
