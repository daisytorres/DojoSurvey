using System.ComponentModel.DataAnnotations;

namespace DojoSurvey.Models;

public class User
{
    [Required(ErrorMessage = "Name is requried 🤠")]
    [MinLength(2, ErrorMessage="Name must be at least 2 characters in length 😮‍💨")]
    public string Name {get;set;} 
    [Required]
    [SelectOption("San Francisco", "Los Angeles", "Chicago")]
    public string Location {get;set;}
    [Required]
    [SelectOption("JavaScript", "Python", "C#")]
    public string FavoriteLanguage {get;set;}
    [MinLength(20, ErrorMessage = "Comment must be at least 20 characters 🥺")]
    public string? Comment {get;set;} //denotes that we can have a nullable field here
}


public class SelectOptionAttribute : ValidationAttribute
{    
    public string[]? Options {get;set;}

    public SelectOptionAttribute(params string[] options)
    {
        this.Options = options;
    }
    // Call upon the protected IsValid method
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)    
    {   

        if (value == null || Options.Contains((string)value))
        {        
            // We were successful and can report our success  
            return ValidationResult.Success;  
        } else {   
            // otherwise we return an error message in ValidationResult we want to render    
            return new ValidationResult("Please choose a selection from the drop down menu 🫨");   
        }  
    }
}