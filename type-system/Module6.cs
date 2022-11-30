using System;
using BethanysPieShopHRM;

namespace type_system
{
    public class Module6
    {
        public Module6()
        {
            //Module 6 Understanding Value Types and Reference Types
            List<string> list = new List<string>();

            UsingEnumerations();

            UsingAStruct();
        }

        private static void UsingEnumerations()
        {
            EmployeeType employeeType = EmployeeType.Manager;
            StoreType storeType = StoreType.Seating;
            int baseWage = 1000;

            CalculateWage(baseWage, employeeType, storeType);
        }

        private static void UsingAStruct()
        {
            Employee employee;
            employee.Name = "Bethany";
            employee.Wage = 1250;
            employee.Work();
        }

        private static void CalculateWage(int baseWage, EmployeeType employeeType, StoreType storeType)
        {
            int calculatedWage = 0;

            if (employeeType == EmployeeType.Manager)
            {
                calculatedWage = baseWage * 3;
            }
            else
            {
                calculatedWage *= 2;
            }

            if (storeType == StoreType.FullPieRestaurant)
            {
                calculatedWage += 500;
            }

            Console.WriteLine($"The calcualted wage is {calculatedWage}");
        }
    }

    enum EmployeeType
    {
        Sales,
        Manager,
        Research,
        StoreManager
    }

    enum StoreType
    {
        PieCorner = 10,
        Seating = 20,
        FullPieRestaurant = 100,
        Undefined = 99
    }

    struct Employee
    {
        public string Name;
        public int Wage;

        public void Work()
        {
            Console.WriteLine($"{Name} is now doing work!");
        }
    }
}

