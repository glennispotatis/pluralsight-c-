using System;
using System.Text;

namespace type_system
{
    public class Module4
    {
        public Module4()
        {
            //Module 4 Creating and Using Strings

            string firstName = "Bethany";
            string lastName = "Smith";

            string fullName = "Bethany Smith";
            string noValueString = null;
            string s;

            s = firstName;

            var userName = "BethanyS";

            //string fullName = firstName + " " + lastName;
            string employeeIdentification = string.Concat(firstName, lastName);

            string empId = firstName.ToLower() + "-" + lastName.Trim().ToLower();

            int length = empId.Length;

            if (fullName.Contains("beth") || fullName.Contains("Beth"))
            {
                Console.WriteLine("It's Bethany!");
            }

            string subString = fullName.Substring(1, 3);
            Console.WriteLine("Characters 2 to 4 of fullName are " + subString);

            string nameUsingInterpolation = $"{firstName}-{lastName}";
            string greeting = $"Hello, {firstName.ToLower()}";

            string displayName = $"Welcome!\n{firstName}\t{lastName}";
            Console.WriteLine(displayName);

            string invalidFilePath = "C:\\data\\employeelist.xlsx";
            string marketingTagLine = "Baking the \"best pies\" ever";
            string verbatimFilePath = @"C:\data\employeelist.xlsx";

            string name1 = "Bethany";
            string name2 = "BETHANY";

            Console.WriteLine("Are both names equal? " + (name1 == name2));
            Console.WriteLine("Is name equal to Bethany? " + (name1 == "Bethany"));
            Console.WriteLine("Is name equal to BETHANY? " + (name2.Equals("BETHANY")));
            Console.WriteLine("Is lower name equal to bethany? " + (name1.ToLower() == "bethany"));

            string name = "Bethany";
            string anotherName = name;

            name += " Smith";

            Console.WriteLine("Name " + name);
            Console.WriteLine("Another name " + anotherName);

            string lowerCaseName = name.ToLower();

            string indexes = string.Empty;
            for (int i = 0; i < 2500; i++)
            {
                indexes += i.ToString();
            }

            StringBuilder builder = new StringBuilder();
            builder.Append("Last name: ");
            builder.AppendLine(lastName);
            builder.Append("First name: ");
            builder.Append(firstName);
            string result = builder.ToString();
            Console.WriteLine(result);

            Console.WriteLine("Enter the wage:");
            string wage = Console.ReadLine();

            //int wageValue = int.Parse(wage);
            int wageValue;
            if (int.TryParse(wage, out wageValue))
                Console.WriteLine("Parsing success: " + wageValue);
            else
                Console.WriteLine("Parsing failed");
        }
    }
}

