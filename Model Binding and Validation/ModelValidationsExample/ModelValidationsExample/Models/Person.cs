using ModelValidationsExample.CustomValidators;
using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.Models
{
    public class Person : IValidatableObject
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Person Name can not be null or empty")]
       // [RegularExpression("^[A-Za-z]$", ErrorMessage = "Person Name should contains alphabets only")]
        public string? PersonName { get; set; }
        
        [Required(ErrorMessage ="Email id can not be null or empty")]
        [EmailAddress(ErrorMessage ="Email ID should be in valid format")]
        public string? Email { get; set;}

        [Required(ErrorMessage ="Phone number can not be null or empty")]
        [StringLength(10, MinimumLength =10, ErrorMessage ="Phone number should be of 10 digit")]
        [Phone(ErrorMessage = "Phone no should be valid")]
        public string? Phone { get; set;}

        [Required(ErrorMessage = "Password is required")]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [Compare("Password", ErrorMessage = "Password and Confirm Password do not match")]
        public string? ConfirmPassword { get; set;}

        [Range(0, 999.99, ErrorMessage = "Price should be between 0 to 999.99")]
        public double? Price { get; set; }

        [MinimumYearValidationAttribute(2000, ErrorMessage = "Date should be greater than 01/01/2000")]
        public DateTime? DOB { get; set; }


        public DateTime FromDate { get; set; }

        [DateRangeValidator("FromDate", ErrorMessage = "From date should be older than or equal to To date")]
        public DateTime ToDate { get; set; }

        public int? Age { get; set; }

        public override string ToString()
        {
            return $"Person Object - Person name : {PersonName} , Email : {Email}, Phone : {Phone}, Passowrd : {Password}, ConfirmPassword : {ConfirmPassword}, Price : {Price} , Date of birth : {DOB}";
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!DOB.HasValue && !Age.HasValue)
            {
                yield return new ValidationResult("Either of DOB or Age must be supplied");
            }
        }
    }
}
