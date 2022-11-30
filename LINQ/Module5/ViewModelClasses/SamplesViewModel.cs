using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public void SequenceEqualIntegers()
        {
            bool value;
            List<int> list1 = new List<int> { 1, 2, 3, 4, 5 };
            List<int> list2 = new List<int> { 1, 2, 3, 4, 6 };

            if (UseQuerySyntax)
            {
                // Query
                value = (from num in list1 select num).SequenceEqual(list2);
            }
            else
            {
                // Method
                value = list1.SequenceEqual(list2);
            }

            if (value)
            {
                ResultText = "Lists are Equal";
            }
            else
            {
                ResultText = "Lists are not Equal";
            }
        }

        public void SequenceEqualProducts()
        {
            bool value;
            List<Product> list1 = new List<Product>
            {
                new Product {ProductID = 1, Name = "Product 1"},
                new Product {ProductID = 1, Name = "Product 2"}
            };

            List<Product> list2 = new List<Product>
            {
                new Product {ProductID = 1, Name = "Product 1"},
                new Product {ProductID = 2, Name = "Product 2"}
            };

            if (UseQuerySyntax)
            {
                // Query
                value = (from prod in list1 select prod).SequenceEqual(list2);
            }
            else
            {
                value = list1.SequenceEqual(list2);
            }

            if (value)
            {
                ResultText = "Lists are Equal";
            }
            else
            {
                ResultText = "Lists are NOT Equal";
            }

            Products.Clear();
        }

        public void SequenceEqualUsingComparer()
        {
            bool value;
            ProductComparer pc = new ProductComparer();
            List<Product> list1 = ProductRepository.GetAll();
            List<Product> list2 = ProductRepository.GetAll();

            list1.RemoveAt(0);

            if (UseQuerySyntax)
            {
                // Query
                value = (from prod in list1 select prod).SequenceEqual(list2, pc);
            }
            else
            {
                // Method
                value = list1.SequenceEqual(list2, pc);
            }

            if (value)
                ResultText = "Lists are Equal";
            else
                ResultText = "Lists are NOT Equal";

            Products.Clear();
        }

        public void ExceptIntegers()
        {
            List<int> exceptions;
            List<int> list1 = new List<int> { 1, 2, 3, 4 };
            List<int> list2 = new List<int> { 3, 4, 5 };

            if (UseQuerySyntax)
                exceptions = (from prod in list1 select prod).Except(list2).ToList();
            else
                exceptions = list1.Except(list2).ToList();

            ResultText = string.Empty;
            foreach (var item in exceptions)
                ResultText += "Number " + item + Environment.NewLine;

            Products.Clear();
        }

        public void Except()
        {
            ProductComparer pc = new ProductComparer();
            List<Product> list1 = ProductRepository.GetAll();
            List<Product> list2 = ProductRepository.GetAll();

            list2.RemoveAll(prod => prod.Color == "Black");

            if (UseQuerySyntax)
                Products = (from prod in list1 select prod).Except(list2, pc).ToList();
            else
                Products = list1.Except(list2, pc).ToList();

            ResultText = $"Total Products: {Products.Count}";
            Products.Clear();
        }

        public void Intersect()
        {
            ProductComparer pc = new ProductComparer();
            List<Product> list1 = ProductRepository.GetAll();
            List<Product> list2 = ProductRepository.GetAll();

            list1.RemoveAll(prod => prod.Color == "Black");
            list2.RemoveAll(prod => prod.Color == "Red");

            if (UseQuerySyntax)
                Products = (from prod in list1 select prod).Intersect(list2, pc).ToList();
            else
                Products = list1.Intersect(list2, pc).ToList();

            ResultText = $"Total Products: {Products.Count}";
            Products.Clear();
        }

        public void Union()
        {
            ProductComparer pc = new ProductComparer();
            List<Product> list1 = ProductRepository.GetAll();
            List<Product> list2 = ProductRepository.GetAll();

            if (UseQuerySyntax)
                Products = (from prod in list1 select prod).Union(list2, pc).OrderBy(prod => prod.Name).ToList();
            else
                Products = list1.Union(list2, pc).OrderBy(prod => prod.Name).ToList();

            ResultText = $"Total Products: {Products.Count}";
            Products.Clear();
        }

        public void LINQConcat()
        {
            List<Product> list1 = ProductRepository.GetAll();
            List<Product> list2 = ProductRepository.GetAll();
            if (UseQuerySyntax)
                Products = (from prod in list1 select prod).Concat(list2).OrderBy(prod => prod.Name).ToList();
            else
                Products = list1.Concat(list2).OrderBy(prod => prod.Name).ToList();

            ResultText = $"Total Products: {Products.Count}";
            Products.Clear();
        }

        public void InnerJoin()
        {
            StringBuilder sb = new StringBuilder(2048);
            int count = 0;

            if (UseQuerySyntax)
            {
                var query = (from prod in Products
                             join sale in Sales on prod.ProductID equals sale.ProductID
                             select new
                             {
                                 prod.ProductID,
                                 prod.Name,
                                 prod.Color,
                                 prod.StandardCost,
                                 prod.ListPrice,
                                 prod.Size,
                                 sale.SalesOrderID,
                                 sale.OrderQty,
                                 sale.UnitPrice,
                                 sale.LineTotal
                             });

                foreach (var item in query)
                {
                    count++;
                    sb.AppendLine($"Sales Order: {item.SalesOrderID}");
                    sb.AppendLine($"  Product ID: {item.ProductID}");
                    sb.AppendLine($"  Product Name: {item.Name}");
                    sb.AppendLine($"  Size: {item.Size}");
                    sb.AppendLine($"  Order Qty: {item.OrderQty}");
                    sb.AppendLine($"  Total: {item.LineTotal}c");
                }
            }
            else
            {
                var query = Products.Join(Sales, prod => prod.ProductID, sale => sale.ProductID, (prod, sale) => new
                {
                    prod.ProductID,
                    prod.Name,
                    prod.Color,
                    prod.StandardCost,
                    prod.ListPrice,
                    prod.Size,
                    sale.SalesOrderID,
                    sale.OrderQty,
                    sale.UnitPrice,
                    sale.LineTotal
                });

                foreach (var item in query)
                {
                    count++;
                    sb.AppendLine($"Sales Order: {item.SalesOrderID}");
                    sb.AppendLine($"  Product ID: {item.ProductID}");
                    sb.AppendLine($"  Product Name: {item.Name}");
                    sb.AppendLine($"  Size: {item.Size}");
                    sb.AppendLine($"  Order Qty: {item.OrderQty}");
                    sb.AppendLine($"  Total: {item.LineTotal}c");
                }
            }

            ResultText = sb.ToString() + Environment.NewLine + "Total Sales: " + count.ToString();
            Products.Clear();
        }

        public void InnerJoinTwoFields()
        {
            short qty = 6;
            int count = 0;

            StringBuilder sb = new StringBuilder(2048);

            if (UseQuerySyntax)
            {
                var query = (from prod in Products join sale in Sales on new { prod.ProductID, Qty = qty } equals new { sale.ProductID, Qty = sale.OrderQty } select new
                {
                    prod.ProductID,
                    prod.Name,
                    prod.Color,
                    prod.StandardCost,
                    prod.ListPrice,
                    prod.Size,
                    sale.SalesOrderID,
                    sale.OrderQty,
                    sale.UnitPrice,
                    sale.LineTotal
                });

                foreach (var item in query)
                {
                    count++;
                    sb.AppendLine($"Sales Order: {item.SalesOrderID}");
                    sb.AppendLine($"  Product ID: {item.ProductID}");
                    sb.AppendLine($"  Product Name: {item.Name}");
                    sb.AppendLine($"  Size: {item.Size}");
                    sb.AppendLine($"  Order Qty: {item.OrderQty}");
                    sb.AppendLine($"  Total: {item.LineTotal}c");
                }
            }
            else
            {
                var query = Products.Join(Sales, prod => new { prod.ProductID, Qty = qty }, sale => new { sale.ProductID, Qty = sale.OrderQty }, (prod, sale) => new
                {
                    prod.ProductID,
                    prod.Name,
                    prod.Color,
                    prod.StandardCost,
                    prod.ListPrice,
                    prod.Size,
                    sale.SalesOrderID,
                    sale.OrderQty,
                    sale.UnitPrice,
                    sale.LineTotal
                });

                foreach (var item in query)
                {
                    count++;
                    sb.AppendLine($"Sales Order: {item.SalesOrderID}");
                    sb.AppendLine($"  Product ID: {item.ProductID}");
                    sb.AppendLine($"  Product Name: {item.Name}");
                    sb.AppendLine($"  Size: {item.Size}");
                    sb.AppendLine($"  Order Qty: {item.OrderQty}");
                    sb.AppendLine($"  Total: {item.LineTotal}c");
                }
            }

            ResultText = sb.ToString() + Environment.NewLine + "Total Sales: " + count.ToString();
            Products.Clear();
        }

        public void GroupJoin()
        {
            StringBuilder sb = new StringBuilder();
            IEnumerable<ProductSales> grouped;

            if (UseQuerySyntax)
            {
                grouped = (from prod in Products
                           join sale in Sales on prod.ProductID equals sale.ProductID into sales
                           select new ProductSales
                           {
                               Product = prod,
                               Sales = sales
                           });
            }
            else
            {
                grouped = Products.GroupJoin(Sales, prod => prod.ProductID, sale => sale.ProductID, (prod, sales) => new ProductSales
                {
                    Product = prod,
                    Sales = sales
                });
            }

            foreach (var ps in grouped)
            {
                sb.AppendLine($"product: {ps.Product}");

                if (ps.Sales.Count() > 0)
                {
                    sb.AppendLine("  ** Sales **");
                    foreach (var sale in ps.Sales)
                    {
                        sb.Append($"    SalesOrderID: {sale.SalesOrderID}");
                        sb.Append($"    Qty: {sale.OrderQty}");
                        sb.AppendLine($"    Total: {sale.LineTotal}");
                    }
                }
                else
                {
                    sb.AppendLine("  ** No Sales for Product **");
                }
                sb.AppendLine("");
            }

            ResultText = sb.ToString();
            Products.Clear();
        }

        public void LeftOuterJoin()
        {
            StringBuilder sb = new StringBuilder(2048);
            int count = 0;

            if (UseQuerySyntax)
            {
                var query = (from prod in Products
                             join sale in Sales on prod.ProductID equals sale.ProductID into sales
                             from sale in sales.DefaultIfEmpty()
                             select new
                             {
                                 prod.ProductID,
                                 prod.Name,
                                 prod.Color,
                                 prod.StandardCost,
                                 prod.ListPrice,
                                 prod.Size,
                                 sale?.SalesOrderID,
                                 sale?.OrderQty,
                                 sale?.UnitPrice,
                                 sale?.LineTotal
                             }).OrderBy(ps => ps.Name);

                foreach (var item in query)
                {
                    count++;
                    sb.AppendLine($"Product Name: {item.Name} ({item.ProductID})");
                    sb.AppendLine($"  Order ID: {item.SalesOrderID}");
                    sb.AppendLine($"  Size: {item.Size}");
                    sb.AppendLine($"  Order Qty: {item.OrderQty}");
                    sb.AppendLine($"  Total: {item.LineTotal}");
                }
            }
            else
            {
                var query = Products.SelectMany(sale => Sales.Where(s => sale.ProductID == s.ProductID).DefaultIfEmpty(), (prod, sale) => new
                {
                    prod.ProductID,
                    prod.Name,
                    prod.Color,
                    prod.StandardCost,
                    prod.ListPrice,
                    prod.Size,
                    sale?.SalesOrderID,
                    sale?.OrderQty,
                    sale?.UnitPrice,
                    sale?.LineTotal
                }).OrderBy(ps => ps.Name);

                foreach (var item in query)
                {
                    count++;
                    sb.AppendLine($"Product Name: {item.Name} ({item.ProductID})");
                    sb.AppendLine($"  Order ID: {item.SalesOrderID}");
                    sb.AppendLine($"  Size: {item.Size}");
                    sb.AppendLine($"  Order Qty: {item.OrderQty}");
                    sb.AppendLine($"  Total: {item.LineTotal}");
                }
            }

            ResultText = sb.ToString();
            Products.Clear();
        }

        public void GroupBy()
        {
            StringBuilder sb = new StringBuilder(2048);
            // IGrouping<key, T>
            IEnumerable<IGrouping<string, Product>> sizeGroup;

            if (UseQuerySyntax)
                sizeGroup = (from prod in Products orderby prod.Size group prod by prod.Size);
            else
                sizeGroup = Products.OrderBy(prod => prod.Size).GroupBy(prod => prod.Size);

            foreach (var group in sizeGroup)
            {
                sb.AppendLine($"Size: {group.Key}  Count: {group.Count()}");

                foreach (var prod in group)
                {
                    sb.Append($"  ProductID: {prod.ProductID}");
                    sb.Append($"  Name: {prod.Name}");
                    sb.AppendLine($"  Color: {prod.Color}");
                }
            }

            ResultText = sb.ToString();
            Products.Clear();
        }

        public void GroupByIntoSelect()
        {
            StringBuilder sb = new StringBuilder(2048);
            IEnumerable<IGrouping<string, Product>> sizeGroup;

            if (UseQuerySyntax)
                sizeGroup = (from prod in Products orderby prod.Size group prod by prod.Size into sizes select sizes);
            else
            {
                sizeGroup = Products.OrderBy(prod => prod.Size).GroupBy(prod => prod.Size);
            }

            foreach (var group in sizeGroup)
            {
                sb.AppendLine($"Size: {group.Key}  Count: {group.Count()}");

                foreach (var prod in group)
                {
                    sb.Append($"  ProductID: {prod.ProductID}");
                    sb.Append($"  Name: {prod.Name}");
                    sb.AppendLine($"  Color: {prod.Color}");
                }
            }

            ResultText = sb.ToString();
            Products.Clear();
        }

        public void GroupByOrderByKey()
        {
            StringBuilder sb = new StringBuilder(2048);
            IEnumerable<IGrouping<string, Product>> sizeGroup;

            if (UseQuerySyntax)
                sizeGroup = (from prod in Products group prod by prod.Size into sizes orderby sizes.Key select sizes);
            else
                sizeGroup = Products.GroupBy(prod => prod.Size).OrderBy(sizes => sizes.Key).Select(sizes => sizes);

            foreach (var group in sizeGroup)
            {
                sb.AppendLine($"Size: {group.Key}  Count: {group.Count()}");

                foreach (var prod in group)
                {
                    sb.Append($"  ProductID: {prod.ProductID}");
                    sb.Append($"  Name: {prod.Name}");
                    sb.AppendLine($"  Color: {prod.Color}");
                }
            }

            ResultText = sb.ToString();
            Products.Clear();
        }

        public void GroupByWhere()
        {
            StringBuilder sb = new StringBuilder(2048);
            IEnumerable<IGrouping<string, Product>> sizeGroup;

            if (UseQuerySyntax)
                sizeGroup = (from prod in Products group prod by prod.Size into sizes where sizes.Count() > 2 select sizes);
            else
                sizeGroup = Products.GroupBy(prod => prod.Size).Where(sizes => sizes.Count() > 2).Select(sizes => sizes);

            foreach (var group in sizeGroup)
            {
                sb.AppendLine($"Size: {group.Key}  Count: {group.Count()}");

                foreach (var prod in group)
                {
                    sb.Append($"  ProductID: {prod.ProductID}");
                    sb.Append($"  Name: {prod.Name}");
                    sb.AppendLine($"  Color: {prod.Color}");
                }
            }

            ResultText = sb.ToString();
            Products.Clear();
        }

        public void GroupedSubquery()
        {
            StringBuilder sb = new StringBuilder(2048);
            IEnumerable<SaleProducts> salesGroup;

            if (UseQuerySyntax)
            {
                salesGroup = (from sale in Sales
                              group sale by sale.SalesOrderID into sales
                              select new SaleProducts
                              {
                                  SalesOrderID = sales.Key,
                                  Products = (from prod in Products join sale in Sales on prod.ProductID equals sale.ProductID where sale.SalesOrderID == sales.Key select prod).ToList()
                              });
            }
            else
            {
                salesGroup = Sales.GroupBy(sale => sale.SalesOrderID).Select(sales => new SaleProducts
                {
                    SalesOrderID = sales.Key,
                    Products = Products.Join(sales, prod => prod.ProductID, sale => sale.ProductID, (prod, sale) => prod).ToList()
                });
            }

            foreach (var sale in salesGroup)
            {
                sb.AppendLine($"Sales ID: {sale.SalesOrderID}");

                if (sale.Products.Count > 0)
                {
                    foreach (var prod in sale.Products)
                    {
                        sb.Append($"  ProductID: {prod.ProductID}");
                        sb.Append($"  Name: {prod.Name}");
                        sb.AppendLine($"  Color: {prod.Color}");
                    }
                }
            }

            ResultText = sb.ToString();
            Products.Clear();
        }

        public void Count()
        {
            int value;

            if (UseQuerySyntax)
                value = (from prod in Products select prod).Count();
            else
                value = Products.Count();

            ResultText = $"Total Products = {value}";
            Products.Clear();
        }

        public void CountFiltered()
        {
            string search = "Red";
            int value;

            if (UseQuerySyntax)
                value = (from prod in Products select prod).Count(prod => prod.Color == search);
            else
                value = Products.Count(prod => prod.Color == search);

            ResultText = $"Total Products with a color of '{search}' = {value}";
            Products.Clear();
        }

        public void Minimum()
        {
            decimal? value;

            if (UseQuerySyntax)
                value = (from prod in Products select prod.ListPrice).Min();
            else
                value = Products.Min(prod => prod.ListPrice);

            if (value.HasValue)
                ResultText = $"Minimum List Price = {value.Value:c}";
            else
                ResultText = "No list Prices Exist.";
            Products.Clear();
        }

        public void Maximum()
        {
            decimal? value;

            if (UseQuerySyntax)
                value = (from prod in Products select prod.ListPrice).Max();
            else
                value = Products.Max(prod => prod.ListPrice);

            if (value.HasValue)
                ResultText = $"Maximum List Price = {value.Value:c}";
            else
                ResultText = "No list Pries Exist.";

            Products.Clear();
        }

        public void Average()
        {
            decimal? value;

            if (UseQuerySyntax)
                value = (from prod in Products select prod.ListPrice).Average();
            else
                value = Products.Average(prod => prod.ListPrice);

            if (value.HasValue)
                ResultText = $"Average List Price = {value.Value:c}";
            else
                ResultText = "No list Pries Exist.";

            Products.Clear();
        }

        public void Sum()
        {
            decimal? value;

            if (UseQuerySyntax)
                value = (from prod in Products select prod.ListPrice).Sum();
            else
                value = Products.Sum(prod => prod.ListPrice);

            if (value.HasValue)
                ResultText = $"Sum List Price = {value.Value:c}";
            else
                ResultText = "No list Pries Exist.";

            Products.Clear();
        }

        public void AggregateSum()
        {
            decimal? value = 0;

            if (UseQuerySyntax)
                value = (from prod in Products select prod).Aggregate(0M, (sum, prod) => sum += prod.ListPrice);
            else
                value = Products.Aggregate(0M, (sum, prod) => sum += prod.ListPrice);

            if (value.HasValue)
                ResultText = $"Total of all List Prices = {value.Value:c}";
            else
                ResultText = "No list Pries Exist.";

            Products.Clear();
        }

        public void AggregateCustom()
        {
            decimal? value = 0;

            if (UseQuerySyntax)
                value = (from sale in Sales select sale).Aggregate(0M, (sum, sale) => sum += (sale.OrderQty * sale.UnitPrice));
            else
                value = Sales.Aggregate(0M, (sum, sale) => sum += (sale.OrderQty * sale.UnitPrice));

            if (value.HasValue)
                ResultText = $"Total of all List Price = {value.Value:c}";
            else
                ResultText = "No list Pries Exist.";

            Products.Clear();
        }

        public void AggregateUsingGrouping()
        {
            StringBuilder sb = new StringBuilder(2040);

            if (UseQuerySyntax)
            {
                var stats = (from prod in Products group prod by prod.Size into sizeGroup where sizeGroup.Count() > 0 select new
                {
                    Size = sizeGroup.Key,
                    TotalProducts = sizeGroup.Count(),
                    Max = sizeGroup.Max(s => s.ListPrice),
                    Min = sizeGroup.Min(s => s.ListPrice),
                    Average = sizeGroup.Average(s => s.ListPrice)
                }
                into result orderby result.Size select result);

                foreach (var stat in stats)
                {
                    sb.AppendLine($"Size: {stat.Size}  Count: {stat.TotalProducts}");
                    sb.AppendLine($"  Min: {stat.Min:c}");
                    sb.AppendLine($"  Max: {stat.Max:c}");
                    sb.AppendLine($"  Average: {stat.Average:c}");
                }
            }
            else
            {
                 var stats = Products.GroupBy(sale => sale.Size).Where(sizeGroup => sizeGroup.Count() > 0).Select(sizeGroup => new
                {
                    Size = sizeGroup.Key,
                    TotalProducts = sizeGroup.Count(),
                    Max = sizeGroup.Max(s => s.ListPrice),
                    Min = sizeGroup.Min(s => s.ListPrice),
                    Average = sizeGroup.Average(s => s.ListPrice)
                }).OrderBy(result => result.Size).Select(result => result);

                foreach (var stat in stats)
                {
                    sb.AppendLine($"Size: {stat.Size}  Count: {stat.TotalProducts}");
                    sb.AppendLine($"  Min: {stat.Min:c}");
                    sb.AppendLine($"  Max: {stat.Max:c}");
                    sb.AppendLine($"  Average: {stat.Average:c}");
                }
            }

            ResultText = sb.ToString();
            Products.Clear();
        }

        public void AggregateUsingGroupingMoreEfficient()
        {
            StringBuilder sb = new StringBuilder(2048);

            // Method syntax only!
            var stats = Products.GroupBy(sale => sale.Size).Where(sizeGroup => sizeGroup.Count() > 0).Select(sizeGroup =>
            {
                var results = sizeGroup.Aggregate(new ProductStats(), (acc, prod) => acc.Accumulate(prod), acc => acc.ComputeAverage());
                return new
                {
                    Size = sizeGroup.Key,
                    results.TotalProducts,
                    results.Min,
                    results.Max,
                    results.Average
                };
            }).OrderBy(result => result.Size).Select(result => result);

            foreach ( var stat in stats)
            {
                sb.AppendLine($"Size: {stat.Size}  Count: {stat.TotalProducts}");
                sb.AppendLine($"  Min: {stat.Min:c}");
                sb.AppendLine($"  Max: {stat.Max:c}");
                sb.AppendLine($"  Average: {stat.Average:c}");
            }

            ResultText = sb.ToString();
            Products.Clear();
        }

        #region Module 11

        #endregion
    }
}

