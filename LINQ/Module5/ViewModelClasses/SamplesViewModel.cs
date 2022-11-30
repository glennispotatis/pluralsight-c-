using System;
using System.Collections.Generic;
using System.Linq;

namespace LINQSamples
{
    public class SamplesViewModel
    {
        public SamplesViewModel()
        {
            Products = ProductRepository.GetAll();
            Sales = SalesOrderDetailRepository.GetAll();
        }

        public bool UseQuerySyntax { get; set; }
        public List<Product> Products { get; set; }
        public List<SalesOrderDetail> Sales { get; set; }
        public string ResultText { get; set; }

        public void All()
        {
            string search = " ";
            bool value;

            if (UseQuerySyntax)
            {
                // Query
                value = (from prod in Products select prod).All(prod => prod.Name.Contains(search));
            }
            else
            {
                //Method
                value = Products.All(prod => prod.Name.Contains(search));
            }

            ResultText = $"Do all Name properties contain a '{search}'? {value}";

            Products.Clear();
        }

        public void Any()
        {
            string search = "z";
            bool value;

            if (UseQuerySyntax)
            {
                // Query
                value = (from prod in Products select prod).Any(prod => prod.Name.Contains(search));
            }
            else
            {
                //Method
                value = Products.Any(prod => prod.Name.Contains(search));
            }

            ResultText = $"Do any Name properties contain a '{search}'? {value}";

            Products.Clear();
        }

        public void LINQContains()
        {
            bool value;
            List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };

            if (UseQuerySyntax)
            {
                // Query
                value = (from num in numbers select num).Contains(3);
            }
            else
            {
                // Method
                value = numbers.Contains(3);
            }

            ResultText = $"Is the number in collection? {value}";

            Products.Clear();
        }

        public void ForEach()
        {
            if (UseQuerySyntax)
            {
                // Query
                Products = (from prod in Products let tmp = prod.NameLength = prod.Name.Length select prod).ToList();
            }
            else
            {
                // Method
                Products.ForEach(prod => prod.NameLength = prod.Name.Length);
            }

            ResultText = $"Total Products: {Products.Count}";
        }

        public void ForEachCallingMethod()
        {
            if (UseQuerySyntax)
            {
                // Query
                Products = (from prod in Products let tmp = prod.TotalSales = SalesForProduct(prod) select prod).ToList();
            }
            else
            {
                // Method
                Products.ForEach(prod => prod.TotalSales = SalesForProduct(prod));
            }

            ResultText = $"Total Products: {Products.Count}";
        }

        private decimal SalesForProduct (Product prod)
        {
            return Sales.Where(sale => sale.ProductID == prod.ProductID).Sum(sale => sale.LineTotal);
        }

        public void Take()
        {
            if (UseQuerySyntax)
            {
                // Query
                Products = (from prod in Products orderby prod.Name select prod).Take(5).ToList();
            }
            else
            {
                // Method
                Products = Products.OrderBy(prod => prod.Name).Take(5).ToList();
            }

            ResultText = $"Total Products: {Products.Count}";
        }

        public void TakeWhile()
        {
            if (UseQuerySyntax)
            {
                // Query
                Products = (from prod in Products orderby prod.Name select prod).TakeWhile(prod => prod.Name.StartsWith("A")).ToList();
            }
            else
            {
                // Method
                Products = Products.OrderBy(prod => prod.Name).TakeWhile(prod => prod.Name.StartsWith("A")).ToList();
            }

            ResultText = $"Total Products: {Products.Count}";
        }

        public void Skip()
        {
            if (UseQuerySyntax)
            {
                // Query
                Products = (from prod in Products orderby prod.Name select prod).Skip(20).ToList();
            }
            else
            {
                // Method
                Products = Products.OrderBy(prod => prod.Name).Skip(20).ToList();
            }

            ResultText = $"Total Products: {Products.Count}";
        }

        public void SkipWhile()
        {
            if (UseQuerySyntax)
            {
                // Query
                Products = (from prod in Products orderby prod.Name select prod).SkipWhile(prod => prod.Name.StartsWith("A")).ToList();
            }
            else
            {
                // Method
                Products = Products.OrderBy(prod => prod.Name).SkipWhile(prod => prod.Name.StartsWith("A")).ToList();
            }

            ResultText = $"Total Products: {Products.Count}";
        }

        public void Distinct()
        {
            List<string> colors = new List<string>();

            if (UseQuerySyntax)
            {
                // Query
                colors = (from prod in Products select prod.Color).Distinct().ToList();
            }
            else
            {
                // Method
                colors = Products.Select(prod => prod.Color).Distinct().ToList();
            }

            foreach (var color in colors)
            {
                Console.WriteLine($"Color: {color}");
            }
            Console.WriteLine($"Total Colors: {colors.Count}");

            Products.Clear();
        }

        public void LINQContainsUsingComparer()
        {
            int search = 744;
            bool value;
            ProductIdComparer pc = new ProductIdComparer();
            Product prodToFind = new Product { ProductID = search };

            if (UseQuerySyntax)
            {
                // Query
                value = (from prod in Products select prod).Contains(prodToFind, pc);
            }
            else
            {
                // Method
                value = Products.Contains(prodToFind, pc);
            }

            ResultText = $"Product ID: {search} is in Products Collection = {value}";
            Products.Clear();
        }
    }
}

