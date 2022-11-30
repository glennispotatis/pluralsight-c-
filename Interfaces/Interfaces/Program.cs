using Interfaces.CatalogSaver;
using Interfaces.OddNumbers;
using Polygons.Library;
using System;

namespace Polygons
{
    class Program
    {
        static void Main(string[] args)
        {
            //var square = new Square(5);
            //DisplayPolygon("Square", square);

            //var triangle = new Triangle(5);
            //DisplayPolygon("Triangle", triangle);

            //var octagon = new Octagon(5);
            //DisplayPolygon("Octagon", octagon);

            //Console.Read();

            // ******* Module 5 ******* \\
            Catalog catalog = new Catalog();
            //catalog.Save();

            ISaveable saveable = new Catalog();
            saveable.Save();

            ((ISaveable)catalog).Save();

            var implicitCatalog = new Catalog();
            //implicitCatalog.Save()

            Console.WriteLine("Odd numbers");

            var generator = new OddGenerator();
            foreach (int odd in generator)
            {
                if (odd > 50)
                    break;
                Console.WriteLine(odd);
            }

            Console.Read();
        }
        
        public static void DisplayPolygon (string polygonType, dynamic polygon)
        {
            try
            {
                Console.WriteLine($"{polygonType} Number of Sides: {polygon.NumberOfSides}");
                Console.WriteLine($"{polygonType} Side Length: {polygon.SideLength}");
                Console.WriteLine($"{polygonType} Perimeter: {polygon.GetPerimeter()}");
                Console.WriteLine($"{polygonType} Area: {Math.Round(polygon.GetArea(), 2)}");
                Console.WriteLine();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception thrown while trying to process {polygonType}\n {ex.GetType().Name}");
            }
        }
    }
}