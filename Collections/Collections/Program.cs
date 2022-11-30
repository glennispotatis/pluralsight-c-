using System;

namespace DisplayRoutes
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Module 2
            // Module 2 - Storing Data in an Array
            //BusRoute route40 = new BusRoute(40, "Morecambe", "Preston");
            //BusRoute route42 = new BusRoute(42, "Lancaster", "Blackpool");

            ////BusRoute[] routes =
            ////{
            ////    route40,
            ////    route42,
            ////    new BusRoute(100, "University", "Morecambe"),
            ////    new BusRoute(555, "Lancaster", "Keswick")
            ////};

            ////BusRoute firstRoute = routes[0];
            ////Console.WriteLine($"The first route is {firstRoute}");
            ////Console.WriteLine($"The third route is {routes[2]}");
            ////BusRoute lastRoute = routes[^1];
            ////Console.WriteLine($"The last route is {lastRoute}");

            ////foreach (BusRoute route in routes)
            ////    Console.WriteLine(route);

            //BusRoute[] routes = new BusRoute[4];

            //routes[0] = route40;
            //routes[1] = route42;
            //routes[2] = new BusRoute(100, "University", "Morecambe");
            //routes[3] = new BusRoute(555, "Lancaster", "Keswick");

            //for (int i = 0; i < routes.Length; i++)
            //{
            //    Console.WriteLine(routes[i]);
            //}

            #endregion

            #region Module 3

            // Module 3 - Finding Data in an Array
            //BusRoute[] allRoutes = BusRouteRepository.InitializeRoutes();

            //Console.WriteLine("Where do you want to go to?");
            //string location = Console.ReadLine();

            //BusRoute[] routes = FindBusesTo(allRoutes, location);

            //if (routes.Length > 0)
            //    foreach (BusRoute route in routes)
            //        Console.WriteLine($"You can use route {route}");
            //else
            //    Console.WriteLine($"No routes go to {location}");

            #endregion

            #region Module 4

            // Module 4 - Adding and Removing Data with List<T>
            //List<BusRoute> allRoutes = BusRouteRepository.InitializeRoutes();

            //// Bad approach
            //Console.WriteLine($"Before: There are {allRoutes.Count} routes:");
            //for (int i = 0; i < allRoutes.Count; i++)
            //    Console.WriteLine($"Route: {allRoutes[i]}");

            ////Array.Resize(ref allRoutes, 4); // Bad approach
            ////allRoutes.RemoveAt(2); // remove at index
            //allRoutes.RemoveAll(route => route.Origin.StartsWith("Test")); //Remove with word in list

            //Console.WriteLine($"\r\nAfter: There are {allRoutes.Count} routes:");
            //foreach (BusRoute route in allRoutes)
            //{
            //    Console.WriteLine($"Route: {route}");
            //}

            #endregion

            #region Module 5

            // Module 5 - Dictionaries
            //var allRoutes = BusRouteRepository.InitializeRoutes();

            //Console.WriteLine("Which route do you want to look up?");
            //int number = int.Parse(Console.ReadLine());

            //bool success = allRoutes.ContainsKey(number);

            //if (success)
            //    Console.WriteLine($"The route you asked for is {allRoutes[number]}");
            //else
            //    Console.WriteLine($"There is no route with number {number}");

            //foreach (BusRoute route in allRoutes.Values)
            //    Console.WriteLine(route);

            #endregion

            #region Module 6

            // Module 6 - Sets
            //BusRouteRepository repository = new BusRouteRepository();

            //Console.WriteLine("Where are you?");
            //string startingAt = Console.ReadLine();

            //Console.WriteLine("Where do you want to go?");
            //string goingTo = Console.ReadLine();

            //BusRoute[] originRoutes = repository.FindBusesTo(startingAt);
            //BusRoute[] destinationRoutes = repository.FindBusesTo(goingTo);

            //HashSet<BusRoute> routes = new HashSet<BusRoute>(originRoutes);
            //routes.IntersectWith(destinationRoutes);

            ////BusRoute[] routes = repository.FindBusesBetween(startingAt, goingTo);

            //if (routes.Count > 0) // Length is only for Arrays, Count for everything else
            //    foreach (BusRoute route in routes)
            //        Console.WriteLine($"You can use route {route}");
            //else
            //    Console.WriteLine($"No routes go between {startingAt} and {goingTo}");

            #endregion

            #region Module 7

            //BusRouteRepository repository = new BusRouteRepository();

            //BusTimes times5 = repository.BusTimesRoute5;
            //BusRoute route5 = times5.Route;

            //for (int iPlace = 0; iPlace < route5.PlacesServed.Length; iPlace++)
            //{
            //    Console.Write(route5.PlacesServed[iPlace].PadRight(12));

            //    //for (int iJourney = 0; iJourney < times5.Times.GetLength(1); iJourney++)
            //    //    Console.Write(times5.Times[iPlace, iJourney] + " ");

            //    // Jagged Array
            //    foreach (string time in times5.Times[iPlace])
            //        Console.Write(time + " ");
            //    Console.WriteLine();
            //}

            #endregion
        }
    }
}