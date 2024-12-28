using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace ECommerceApplication.Model
{
    public class Order
    {

        [BindNever]
        public int? OrderNo { get; set; }

        [Required(ErrorMessage = "Orderdate should can not be blank")]
        public DateTime? OrderDate { get; set; }

        [Required(ErrorMessage = "Invoice Price is required")]
        public double? InvoicePrice { get; set; }

        [Required(ErrorMessage = "Product should not be blank")]
        public List<Product>? Products { get; set; }

        //Custom Validation logic

        #region custom validation
        /*
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if(Products == null || Products.Count == 0)
            {
                yield return new ValidationResult("Products can not be null", new[] { nameof(Products) });
            }

            if(InvoicePrice.HasValue)
            {
                double totalProductPrice = 0;

                foreach(var product in Products)
                {
                    totalProductPrice += product.Price;
                }

                if(totalProductPrice != InvoicePrice.Value)
                {
                    yield return new ValidationResult($"The total product price ({totalProductPrice}) does not match the invoice price ({InvoicePrice}).",new[] { nameof(InvoicePrice) });
                }
            }
        }
        */
        #endregion
    }
}
