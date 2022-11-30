using System;
namespace BethanysPieShopHRM.HR
{
    public interface IEmployee
    {
        double ReceiveWage();
        void GiveBonus();
        void PerformWork();
        void StopWorking();
        void DisplayEmployeeDetails();

        void GiveCompliment();
    }
}

