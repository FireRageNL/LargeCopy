namespace LargeCopies.Models
{
    public class Productdb : db
    {
        public bool AddProduct(ProductModel model)
        {
            return true;
        }

        public bool AddTheme(ProductModel model)
        {
            return false;
        }
    }
}