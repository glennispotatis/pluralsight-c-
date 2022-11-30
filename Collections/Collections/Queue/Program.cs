using System;

namespace SimulateJourney
{
    class Program
    {
        static void Main(string[] args)
        {
            BusStop busStop = new BusStop();
            Bus bus = new Bus();

            for (int i = 0; i < 6; i++)
                busStop.PersonArrive(PassengerGenerator.CreatePassenger());

            busStop.BusArrive(bus);
            bus.ArriveAt("Lancaster");
            bus.ArriveAt("Morecambe");
        }
    }
}