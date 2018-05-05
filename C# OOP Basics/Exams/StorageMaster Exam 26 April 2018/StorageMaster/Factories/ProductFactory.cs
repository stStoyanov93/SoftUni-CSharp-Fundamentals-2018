using StorageMaster.Models.Products;
using System;
using System.Linq;
using System.Reflection;

namespace StorageMaster.Factories
{
    public class ProductFactory
    {
        public Product CreateProduct(string type, double price)
        {
            var typeOfProduct = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == type);

            if (typeOfProduct == null)
            {
                throw new InvalidOperationException($"Invalid product type!");
            }

            if (typeOfProduct.Name == "Product")
            {
                throw new InvalidOperationException($"Invalid product type!");
            }

            if (price < 0)
            {
                throw new InvalidOperationException("Price cannot be negative!");
            }

            var product = (Product)Activator.CreateInstance(typeOfProduct, price);
            return product;
        }
    }
}
