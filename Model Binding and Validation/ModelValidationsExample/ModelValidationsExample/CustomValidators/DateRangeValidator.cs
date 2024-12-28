using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace ModelValidationsExample.CustomValidators
{
    public class DateRangeValidator : ValidationAttribute
    {
        public string? FromDate { get; set; }

        public DateRangeValidator(string  FrmDtvalue)
        {
            FromDate = FrmDtvalue;
        }
        

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value != null)
            {
                DateTime toDate = Convert.ToDateTime(value);
                PropertyInfo? otherProperty = validationContext.ObjectType.GetProperty(FromDate!);

                DateTime fromDate = new DateTime();
                if (otherProperty != null)
                {
                    fromDate = Convert.ToDateTime(otherProperty.GetValue(validationContext.ObjectInstance));
                }
                

                if(fromDate > toDate)
                {
                    return new ValidationResult(ErrorMessage);
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
