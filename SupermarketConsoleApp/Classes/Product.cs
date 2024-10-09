using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SupermarketConsoleApp.Classes
{
    internal class Product
    {
        string Name;
        int ProductId;
        double Price;

        private Product(string name, int productId, double price)
        {
            Name = name;
            ProductId = productId;
            Price = price;
        }

        public static void CreateProduct(List<Product> Products, string name, int productId, double price)
        {
            if(string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Помилка: Назва продукту не може бути пустою");
                return;
            }

            if (Products.Any(p => p.Name == name))
            {
                Console.WriteLine($"Помилка: Товар {name} вже iснує ");
                return;
            }

            Products.Add(new Product(name, productId, price));
            return;
        }

        public void GetName()
        {
            Console.WriteLine($"Name: {Name}");
        }
    }
}
