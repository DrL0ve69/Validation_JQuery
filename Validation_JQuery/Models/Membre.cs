using System.ComponentModel.DataAnnotations;

namespace Validation_JQuery.Models;

public class Membre: IValidatableObject
{
    private List<ValidationResult> _validationResults = new List<ValidationResult>();

    [Required(ErrorMessage ="class Membre: Nom requis")]
    [RegularExpression(@"^[A-Z]+[a-zA-Z''-'\s]*$", ErrorMessage =
    "Le champ Nom doit commencer par une majuscule et contenir uniquement des lettres.")]
    [StringLength(25, MinimumLength = 4, ErrorMessage = "Minimum de 4 caractères & 25 maximum.")]
    public string Nom { get; set; }


    [Required(ErrorMessage = "class Membre: Prénom requis")]
    [Display(Name = "Prénom")]
    [Length(3,25,ErrorMessage ="Minimum de 3 caractères & 25 maximum.")]
    public string Prenom { get; set; }

    [Required(ErrorMessage = "class Membre: Email requis")]
    [DataType(DataType.EmailAddress)]
    [EmailAddress(ErrorMessage = "class Membre: Email invalide.")]
    public string Email { get; set; }

    [Required(ErrorMessage = "class Membre: Username ne peut pas être vide")]
    [Display(Name = "Pseudonyme")]
    //[UsernameValid]
    public string Username { get; set; }

    private DateOnly _dateNaissance;
    [Required(ErrorMessage = "class Membre: Date de naissance requise")]
    [DataType(DataType.Date)]
    [Display(Name = "Date de naissance")]
    public DateOnly DateNaissance 
    {
        get => _dateNaissance;
        set 
        {
            if(DateOnly.FromDateTime(DateTime.UtcNow).Year - value.Year >= 18)
                _dateNaissance = value;
            else 
                _validationResults.Add(new ValidationResult("class Membre setter: Vous devez avoir au moins 18 ans pour vous inscrire.", ["DateNaissance"]));
        }
    }
    public string UserId 
    {
        get 
        {
            if (Nom.Length < 3 || Prenom.Length < 3) 
            {
                return "Non-Valide";
            }
            return $"{Nom.Substring(0, 3).ToUpper()}{Prenom.Substring(0, 1).ToUpper()}_{Username}{DateNaissance.Year}";
        }
    } 
        

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        return _validationResults;
    }
}
