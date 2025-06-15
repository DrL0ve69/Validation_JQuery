using System.ComponentModel.DataAnnotations;

namespace Validation_JQuery.Models;

public class Membre: IValidatableObject
{
    private List<ValidationResult> _validationResults = new List<ValidationResult>();

    [Required(ErrorMessage ="class Membre: Nom requis")]
    public string Nom { get; set; }


    [Required(ErrorMessage = "class Membre: Prénom requis")]
    [Display(Name = "Prénom")]
    public string Prenom { get; set; }

    [Required(ErrorMessage = "class Membre: Email requis")]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required(ErrorMessage = "class Membre: Username ne peut pas être vide")]
    [Display(Name = "Pseudonyme")]
    [UsernameValid]
    public string Username { get; set; }

    [Required(ErrorMessage = "class Membre: Date de naissance requise")]
    [Display(Name = "Date de naissance")]
    [DataType(DataType.Date)]
    public DateOnly DateNaissance { get; set; }
    public string UserId => 
        $"{Nom.Substring(0,3).ToUpper()}{Prenom.Substring(0,1).ToUpper()}_{Username}{DateNaissance.Year}";

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return _validationResults;
    }
}
