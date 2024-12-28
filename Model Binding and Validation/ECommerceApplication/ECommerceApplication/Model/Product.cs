using System.ComponentModel.DataAnnotations;

namespace ECommerceApplication.Model
{
    public class Product
    {
        [Required(ErrorMessage = "Product code should not be blank")]
        public int ProductCode { get; set; }
        [Required(ErrorMessage = "Price should not be blank")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Quantity should bot be blank")]
        public int Quantity { get; set; }
    }
}
