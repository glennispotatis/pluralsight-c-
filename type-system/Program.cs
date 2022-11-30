using System;
using System.Text;
using BethanysPieShopHRM.Accounting;
using BethanysPieShopHRM.HR;
using Newtonsoft.Json;

namespace BethanysPieShopHRM
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Creating an employee");
            Console.WriteLine("*--------------------*\n");

            Manager bethany = new Manager(55156, "Bethany", "Smith", "bethany@snowball.be", new DateTime(1979, 1, 16), 25);

            Manager mary = new Manager(748, "Mary", "Jones", "mary@snowball.be", new DateTime(1965, 1, 16), 30);

            JuniorResearcher bobJunior = new JuniorResearcher(11231, "Bob", "Spencer", "bob@snowball.be", new DateTime(1988, 1, 23), 17);
            StoreManager kevin = new StoreManager(81131, "Kevin", "Marks", "kevin@snowball.be", new DateTime(1953, 12, 12), 10);
            StoreManager kate = new StoreManager(100, "Kate", "Greggs", "kate@snowball.be", new DateTime(1993, 8, 8), 10);

            //bethany.DisplayEmployeeDetails();
            //bethany.PerformWork();
            //bethany.PerformWork();
            //bethany.PerformWork();
            //bethany.ReceiveWage();

            //mary.DisplayEmployeeDetails();
            //mary.PerformWork();
            //mary.PerformWork();
            //mary.PerformWork();
            //mary.ReceiveWage();

            //mary.AttendManagementMeeting();

            //bobJunior.ResearchNewPieTastes(10);
            //bobJunior.ReceiveWage();

            //mary.GiveBonus();

            //bethany.GiveBonus();
            //mary.GiveBonus();
            //kate.GiveBonus();

            //Employee[] employees = new Employee[5];
            //employees[0] = bethany;
            //employees[1] = mary;
            //employees[2] = bobJunior;
            //employees[3] = kevin;
            //employees[4] = kate;

            //foreach (var employee in employees)
            //{
            //    employee.PerformWork();
            //    employee.ReceiveWage();
            //    employee.DisplayEmployeeDetails();
            //    employee.GiveBonus();
            //    //Console.WriteLine(employee.ToString());
            //    //employee.AttendManagementMeeting();
            //    Console.WriteLine("*--------------------*\n");
            //}

            List<Employee> employees = new List<Employee>();
            employees.Add(bethany);
            employees.Add(mary);
            employees.Add(bobJunior);
            employees.Add(kevin);
            employees.Add(kate);

            employees.Sort();

            foreach (var employee in employees)
            {
                employee.DisplayEmployeeDetails();
            }
        }
    }
}
