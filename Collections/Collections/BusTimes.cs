using System;
namespace DisplayRoutes
{
    public class BusTimes
    {
        public string[][] Times { get; }
        public BusRoute Route { get; }

        public BusTimes(BusRoute route, string[][] times)
        {
            this.Route = route;
            this.Times = times;
        }
    }
}

