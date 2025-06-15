namespace Validation_JQuery.Models.DataBase;

public interface IMembres_Repository
{
    List<Membre> ListeMembres { get; }  // Liste des membres dans la base de données simulée
    void AjouterMembre(Membre membre);  // Méthode pour ajouter un membre à la liste
    void SupprimerMembre(string username);  // Méthode pour supprimer un membre par son nom d'utilisateur
    void ModifierMembre(Membre membre);  // Méthode pour modifier un membre existant
    Membre GetMembre_Username(string username);  // Méthode pour obtenir un membre par son nom d'utilisateur
}
