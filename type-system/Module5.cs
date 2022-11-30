using System;
using BethanysPieShopHRM;

namespace type_system
{
    public class Module5
    {
        public Module5()
        {
            // Module 5 Working with Methods

            int monthlyWage = 1234;
            int months = 12;
            int bonus = 1000;

            int yearlyWage = CalculateYearlyWage(monthlyWage, months, bonus);
            Console.WriteLine($"Yearly wage: {yearlyWage}");

            UsingValueParameters();
            UsingRefParameters();
            UsingOutParameters();
            UsingParams();
            UsingOptionalParameters();
            UsingNamedArguments();
            UsingExpressionBodiedSyntax();
        }

        private static void UsingValueParameters()
        {
            int monthlyWage1 = 1234;
            int monthlyWage2 = 2000;
            int months1 = 12;
            int months2 = 8;
            int bonus = 300;

            int yearlyWageForEmployee1 = CalculateYearlyWage(monthlyWage1, months1, bonus);
            Console.WriteLine($"Yearly wage for employee 1 (Bethany): {yearlyWageForEmployee1}");

            int yearlyWageForEmployee2 = CalculateYearlyWage(monthlyWage2, months2, bonus);
            Console.WriteLine($"Yearly wage for employee 2 (John): {yearlyWageForEmployee2}");
        }

        public static int CalculateYearlyWage(int monthlyWage, int numberOfMonthsWorked, int bonus)
        {
            if (monthlyWage < 2000)
                bonus *= 2;

            Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMonthsWorked + bonus}");
            Console.WriteLine($"The employee got a bonus of {bonus}");
            return monthlyWage * numberOfMonthsWorked + bonus;
        }

        private static void UsingRefParameters()
        {
            int monthlyWage1 = 1234;
            int monthlyWage2 = 2000;
            int months1 = 12;
            int months2 = 8;
            int bonus = 300;

            int yearlyWageForEmployee1 = CalculateYearlyWageByRef(monthlyWage1, months1, ref bonus);
            Console.WriteLine($"Yearly wage for employee 1 (Bethany): {yearlyWageForEmployee1}");

            int yearlyWageForEmployee2 = CalculateYearlyWageByRef(monthlyWage2, months2, ref bonus);
            Console.WriteLine($"Yearly wage for employee 2 (John): {yearlyWageForEmployee2}");
        }

        public static int CalculateYearlyWageByRef(int monthlyWage, int numberOfMonthsWorked, ref int bonus)
        {
            if (monthlyWage < 2000)
            {
                bonus *= 2;
                Console.WriteLine("Bonus doubled!! Yay!!");
            }

            Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMonthsWorked + bonus}");
            return monthlyWage * numberOfMonthsWorked + bonus;

        }

        private static void UsingOutParameters()
        {
            int monthlyWage1 = 1234;
            int months1 = 12;
            int bonus;

            int yearlyWageForEmployee1 = CalculateYearlyWageWithOut(monthlyWage1, months1, out bonus);
            Console.WriteLine($"Yearly wage for employee 1 (Bethany): {yearlyWageForEmployee1}");
            Console.WriteLine($"Bethany received a bonus of {bonus}");
        }

        public static int CalculateYearlyWageWithOut(int monthlyWage, int numberOfMonthsWorked, out int bonus)
        {
            bonus = new Random().Next(1000);
            if (bonus < 500)
            {
                bonus *= 2;
                Console.WriteLine("Bonus doubled!! Yay!!");
            }

            Console.WriteLine($"The yearly wage is : {monthlyWage * numberOfMonthsWorked + bonus}");
            return monthlyWage * numberOfMonthsWorked + bonus;
        }

        private static void UsingParams()
        {
            int monthlyWage1 = 1000, monthlyWage2 = 1234, monthlyWage3 = 1500, monthlyWage4 = 2500;

            int average = CalculateAverageWage(monthlyWage1, monthlyWage2, monthlyWage3, monthlyWage4);
            Console.WriteLine($"The average wage is {average}");
        }

        public static int CalculateAverageWage(params int[] wages)
        {
            int total = 0;
            int numberOfWages = wages.Length;

            for (int i = 0; i < numberOfWages; i++)
            {
                total += wages[i];
            }

            return total / numberOfWages;
        }

        private static void UsingOptionalParameters()
        {
            int monthlyWage1 = 1234;
            int months1 = 12;

            int yearlyWageForEmployee1 = CalculateYearlyWageWithOptional(monthlyWage1, months1);
            Console.WriteLine($"Yearly wage for employee 1 (Bethany): {yearlyWageForEmployee1}");
        }

        public static int CalculateYearlyWageWithOptional(int monthlyWage, int numberOfMonthsWorked, int bonus = 0)
        {
            Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMonthsWorked + bonus}");
            return monthlyWage * numberOfMonthsWorked + bonus;
        }

        private static void UsingNamedArguments()
        {
            int monthlyWage1 = 1234;
            int months = 12;
            int bonus = 500;

            int yearlyWageForEmployee1 = CalculateYearlyWageWithNamed(bonus: bonus, numberOfMonthsWorked: months, monthlyWage: monthlyWage1);
            Console.WriteLine($"The yearly wage for employee: {yearlyWageForEmployee1}");
        }

        public static int CalculateYearlyWageWithNamed(int monthlyWage, int numberOfMonthsWorked, int bonus)
        {
            Console.WriteLine($"The yearly wage is: {monthlyWage * numberOfMonthsWorked + bonus}");
            return monthlyWage * numberOfMonthsWorked + bonus;
        }

        private static void UsingExpressionBodiedSyntax()
        {
            int monthlyWage = 1234;
            int months = 12;
            int bonus = 500;

            int yearlyWageForEmployee1 = CalculateYearlyWageExpressionBodied(monthlyWage, months, bonus);
            Console.WriteLine($"Yearly wage for employee 1 (Bethany): {yearlyWageForEmployee1}");
        }

        public static int CalculateYearlyWageExpressionBodied(int monthlyWage, int numberOfMonthsWorked, int bonus) => monthlyWage * numberOfMonthsWorked + bonus;

        //public static int CalculateYearlyWage(int monthlyWage, int numberOfMonthsWorked)
        //{
        //    //Console.WriteLine($"Yearly wage: {monthlyWage * numberOfMonthsWorked}");
        //    if (numberOfMonthsWorked == 12)
        //    {
        //        return monthlyWage * (numberOfMonthsWorked + 1);
        //    }
        //    return monthlyWage * numberOfMonthsWorked;
        //}

        //public static int CalculateYearlyWage(int monthlyWage, int numberOfMonthsWorked, int bonus)
        //{
        //    return monthlyWage * numberOfMonthsWorked + bonus;
        //}
    }
}

