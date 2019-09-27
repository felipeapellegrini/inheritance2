using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Price_tag.Entities;

namespace Price_tag
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            Console.Write("Enter the number of products: ");
            int numProd = int.Parse(Console.ReadLine());

            for(int i=1; i<=numProd; i++)
            {
                Console.WriteLine($"Product #{i} data:");
                Console.Write("Common, used or imported (c/u/i): ");
                char productClass = char.Parse(Console.ReadLine());
                Console.Write("Name: ");
                string productName = Console.ReadLine();
                Console.Write("Price: ");
                double productPrice = double.Parse(Console.ReadLine());
                if (productClass == 'c')
                {
                    list.Add(new Product(productName, productPrice));
                }
                else if (productClass == 'u')
                {                   
                    Console.Write("Manufacture date: ");
                    DateTime manDate = DateTime.Parse(Console.ReadLine());

                    list.Add(new UsedProduct(productName, productPrice, manDate));
                }
                else if (productClass == 'i')
                {                    
                    Console.Write("Customs fee: ");
                    double customsFee = double.Parse(Console.ReadLine());

                    list.Add(new ImportedProduct(productName, productPrice, customsFee));
                }
                else
                {
                    Console.Write("Type not allowed, restart.");
                    Console.WriteLine();
                    return;
                }

                Console.WriteLine();

                
            }
            Console.WriteLine("PRICE TAGS: ");
            foreach (Product prd in list)
            {
                Console.WriteLine(prd.PriceTag());
            }
        }
    }
}
