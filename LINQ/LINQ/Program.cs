using System;

namespace LINQSamples
{
    class Program
    {
        static void Main(string[] args)
        {
            SamplesViewModel vm = new SamplesViewModel
            {
                UseQuerySyntax = false
            };

            vm.SingleOrDefault();

            foreach(var item in vm.Products)
            {
                Console.WriteLine(item.ToString());
            }

            Console.WriteLine(vm.ResultText);
        }
    }
}