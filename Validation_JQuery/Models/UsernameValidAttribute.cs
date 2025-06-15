using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using Validation_JQuery.Models.DataBase;

namespace Validation_JQuery.Models;

public class UsernameValidAttribute : ValidationAttribute, IClientModelValidator
{
    public override bool IsValid(object value)
    {
        if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
        {
            return true; // Laisse le required s'en charger
        }
        var username = value.ToString();
        // Vérifier si le username existe déjà dans la base de données
        return !DB_Membres_Repository.ListeMembres.Exists(m => m.Username.ToUpper() == username.ToUpper());
    }
    public void AddValidation(ClientModelValidationContext context)
    {
        context.Attributes.Add("data-val", "true");
        context.Attributes.Add("data-val-username_validation", ErrorMessage?? "class UsernameValidAttribute: Message du public void AddValidation");
    }
}

