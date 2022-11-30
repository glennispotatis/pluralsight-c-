using System;
namespace DisplayRoutes
{
    public class BusRoute
    {
        public int Number { get; }
        public string Origin => PlacesServed[0];
        public string Destination => PlacesServed[^1];
        public string[] PlacesServed { get; }

        public BusRoute (int number, string[] placesServed)
        {
            this.Number = number;
            this.PlacesServed = placesServed;
        }

        public override string ToString() => $"{Number}: {Origin} -> {Destination}";

        public bool Serves(string destination)
        {
            //foreach (string place in PlacesServed)
            //{
            //    if (place == destination)
            //        return true;
            //}
            //return false;

            return Array.Exists(PlacesServed, place => place == destination);
        }
    }
}

