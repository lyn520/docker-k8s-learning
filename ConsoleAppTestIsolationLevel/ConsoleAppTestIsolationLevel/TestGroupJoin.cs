using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTestIsolationLevel
{
    public class TestGroupJoin
    {
        public static void Example()
        {
            List<Product> products = new List<Product>
            {
                new Product { Name = "Cola", CategoryId = 0 },
                new Product { Name = "Tea", CategoryId = 0 },
                new Product { Name = "Apple", CategoryId = 1 },
                new Product { Name = "Kiwi", CategoryId = 1 },
                new Product { Name = "Carrot", CategoryId = 3 },
            };

            List<Category> categories = new List<Category>
            {
                new Category { Id = 0, CategoryName = "Beverage" },
                new Category { Id = 1, CategoryName = "Fruit" },
                new Category { Id = 2, CategoryName = "Vegetable" }
            };

            // Join categories and product based on CategoryId and grouping result
            var productGroups = from category in categories
                                join product in products on category.Id equals product.CategoryId into productGroup
                                select new { category, productGroup };

            foreach (var item in productGroups)
            {
                Console.WriteLine($"Group-{item.category.CategoryName}");
                foreach (Product product in item.productGroup)
                {
                    Console.WriteLine($"{product.Name,8}");
                }
            }

            // This code produces the following output:
            //
            // Group
            //     Cola
            //      Tea
            // Group
            //    Apple
            //     Kiwi
            // Group
            //   Carrot
        }
    }
    class Product
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
    }

    class Category
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }


}
