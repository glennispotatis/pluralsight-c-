using System.Text;

namespace LINQSamples
{
    public partial class Product
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal StandardCost { get; set; }
        public decimal ListPrice { get; set; }
        public string Size { get; set; }

        public int? NameLength { get; set; }
        public decimal? TotalSales { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder(1024);

            sb.Append(Name);
            sb.AppendLine($"  ID: {ProductID}");
            sb.Append($"   Color: {Color}");
            sb.AppendLine($"   Size: {(Size ?? "n/a")}");
            sb.Append($"   Cost: {StandardCost:c}");
            sb.AppendLine($"   Price: {ListPrice:c}");
            if (NameLength.HasValue)
            {
                sb.AppendLine($"   Name Length: {NameLength}");
            }
            if (TotalSales.HasValue)
            {
                sb.AppendLine($"   Total Sales: {TotalSales:c}");
            }
            return sb.ToString();
        }

        // Module 11
        //private string _Name;
        //private string _Color;


        //public string Name
        //{
        //    get
        //    {
        //        Console.WriteLine($"** product: {_Name} **");
        //        return _Name;
        //    }
        //    set { _Name = value; }
        //}

        //public string Color
        //{
        //    get
        //    {
        //        Console.WriteLine($"** Color is {_Color} for {Name} **");
        //        return _Color;
        //    }
        //    set { _Color = value; }
        //}

        //public override string ToString()
        //{
        //    return $"From Query: {_Name}";
        //}
    }
}
