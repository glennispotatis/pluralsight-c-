namespace DisplayRoutes
{
    public class BusRouteRepository
    {
        //public static SortedList<int, BusRoute> InitializeRoutes()
        //{
        //    BusRoute route40 = new BusRoute(40, new string[] { "Morecambe", "Lancaster", "Garstrand", "Preston" });
        //    BusRoute route42 = new BusRoute(42, new string[] { "Lancaster", "Garstrang", "Blackpool" });
        //    BusRoute route100 = new BusRoute(100, new string[] { "University", "Lancaster", "Morecambe" });
        //    BusRoute route555 = new BusRoute(555, new string[] { "Lancaster", "Carnforth", "Kendal", "Windermere", "Keswick" });
        //    BusRoute route5 = new BusRoute(5, new string[] { "Overton", "Morecambe", "Carnforth" });

        //    var routes = new SortedList<int, BusRoute>
        //    {
        //        { 42, route42 },
        //        { 40, route40 },
        //        { 100, route100 },
        //        { 555, route555 },
        //        { 5, route5 }
        //    };

        //    return routes;
        //}

        private readonly BusRoute[] _allRoutes;

        public BusRouteRepository()
        {
            _allRoutes = new BusRoute[]
            {
                new BusRoute(40, new string[] { "Morecambe", "Lancaster", "Garstrand", "Preston" }),
                new BusRoute(42, new string[] { "Lancaster", "Garstrang", "Blackpool" }),
                new BusRoute(100, new string[] { "University", "Lancaster", "Morecambe" }),
                new BusRoute(555, new string[] { "Lancaster", "Carnforth", "Kendal", "Windermere", "Keswick" }),
                new BusRoute(5, new string[] { "Overton", "Morecambe", "Carnforth" }),
            };

            //string[,] timesRoute5 =
            //{
            //    { "15:40", "16:40", "17:40", "18:40" },
            //    { "16:08", "17:08", "18:08", "19:08" },
            //    { "16:35", "17:35", "18:35", "19:35" }
            //};

            // Jagged array
            string[][] timesRoute5 =
            {
                new string[] { "15:40", "16:40", "17:40", "18:40", "19:40" },
                new string[] { "16:08", "17:08", "18:08", "19:08", "20:08" },
                new string [] { "16:35", "17:35", "18:35", "19:35" }

            };
            BusTimesRoute5 = new BusTimes(Array.Find(_allRoutes, x => x.Number == 5), timesRoute5);
        }

        public BusTimes BusTimesRoute5 { get; }

        public BusRoute[] FindBusesTo(string location)
        {
            //foreach (BusRoute route in routes)
            //{
            //    if (route.Origin == location || route.Destination == location)
            //        return route;
            //}
            //return null;

            //return Array.FindAll(routes, route => route.Origin == location || route.Destination == location);

            return Array.FindAll(_allRoutes, route => route.Serves(location));
        }

        public BusRoute[] FindBusesBetween(string location1, string location2)
        {
            return Array.FindAll(_allRoutes, route => route.Serves(location1) && route.Serves(location2));
        }
    }
}