﻿using System;
namespace BethanysPieShopHRM.HR
{
    public class Researcher : Employee
    {
        public Researcher(int id, string first, string last, string em, DateTime bd, double? rate) : base(id, first, last, em, bd, rate) { }

        //public override double ReceiveWage()
        //{
        //    double wageBeforeTax = NumberOfHoursWorked * HourlyRate.Value;
        //    double taxAmount = wageBeforeTax * taxRate;

        //    Wage = wageBeforeTax - taxAmount;

        //    Console.WriteLine($"The wage for {NumberOfHoursWorked} hours of work is {Wage}.");
        //    NumberOfHoursWorked = 0;

        //    return Wage;
        //}

        public void ResearchNewPieTastes(int researchHours)
        {
            NumberOfHoursWorked += researchHours;
            Console.WriteLine($"Researcher {FirstName} {LastName} has invented a new pie taste!");
        }
    }

    public class JuniorResearcher : Researcher
    {
        public JuniorResearcher(int id, string first, string last, string em, DateTime bd, double? rate) : base(id, first, last, em, bd, rate) { }
    }
}

