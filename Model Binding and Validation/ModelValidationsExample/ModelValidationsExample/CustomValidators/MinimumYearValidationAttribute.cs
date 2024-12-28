using System.ComponentModel.DataAnnotations;

namespace ModelValidationsExample.CustomValidators
{
    public class MinimumYearValidationAttribute : ValidationAttribute
    {

        public int MinimumYear { get; set; } = 2000;

        public string DeafultErrorMessage { get; set; } = "Invalid date";

        public MinimumYearValidationAttribute(int value)
        {
            MinimumYear= value;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {


            if(value != null)
            {
                DateTime dt = (DateTime)value;

                if (dt.Year >= MinimumYear)
                {
                    if (ErrorMessage != null)
                    {
                        return new ValidationResult(ErrorMessage);
                    }
                    else
                    {
                        return new ValidationResult(DeafultErrorMessage);
                    }
                    
                }
                else
                {
                    return ValidationResult.Success;
                }              
            }

            return null;
        }
    }
}
