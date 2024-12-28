using ECommerceApplication.Model;

namespace ECommerceApplication.CustomValidation
{
    public class InvoiceValidator
    {

        public static bool IsValid(double InvoicePrice, List<Product> products)
        {
            double totalPrice = 0;

            foreach (Product product in products)
            {
                totalPrice += product.Price;
            }

            if(totalPrice == InvoicePrice) {
            
            return true;
            
            }

            return false;
        }
    }
}
