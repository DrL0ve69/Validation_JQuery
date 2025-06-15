namespace Validation_JQuery.Models.DataBase;

public class DB_Membres_Repository : IMembres_Repository
{
    private readonly DB_Projet_Context _context;
    public DB_Membres_Repository(DB_Projet_Context context)
    {
        _context = context;
    }

    public List<Membre> ListeMembres => _context.Membres.ToList();

    public void AjouterMembre(Membre membre)
    {
        _context.Membres.Add(membre);
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
