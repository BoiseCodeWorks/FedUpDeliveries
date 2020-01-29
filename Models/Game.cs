using System.Collections.Generic;

namespace FedUp.Models
{
    class Game
    {
        public Airport CurrentAirport { get; set; }
        public List<Package> Deliveries { get; set; } = new List<Package>();
        public int AccountBalance { get; set; } = 0;
        public void Setup()
        {
            //Create Flights 
            Airport Boise = new Airport("Boise", "BOI");
            Airport Denver = new Airport("Denver", "DEN");
            Airport LosAngeles = new Airport("Los Angeles", "LAX");
            Airport Portland = new Airport("Portland", "PDX");
            Airport Phoenix = new Airport("Phoenix", "PHX");
            Airport NewYork = new Airport("New York", "JFK");
            Airport Miami = new Airport("Miami", "MIA");
            Airport Guadalajara = new Airport("Guadalajara", "GDL");
            Airport Honolulu = new Airport("Honolulu", "HNL");
            Airport Dallas = new Airport("Dallas", "DFW");


            //Create Packages


            // Create Airport Relationships
            Boise.AddDestination(Portland);
            Boise.AddDestination(Denver);
            Denver.AddDestination(LosAngeles);
            Denver.AddDestination(Phoenix);
            Denver.AddDestination(Portland);
            Denver.AddDestination(Miami);
            LosAngeles.AddDestination(Honolulu);
            LosAngeles.AddDestination(Dallas);
            LosAngeles.AddDestination(NewYork);
            LosAngeles.AddDestination(Phoenix);
            LosAngeles.AddDestination(Portland);
            Phoenix.AddDestination(Guadalajara);
            Phoenix.AddDestination(Dallas);
            Phoenix.AddDestination(Miami);
            NewYork.AddDestination(Dallas);
            NewYork.AddDestination(Miami);
            NewYork.AddDestination(Denver);

            //Add packages to airports

            NewYork.Pickups.Add(new Package(LosAngeles.Code, 230));
            Phoenix.Pickups.Add(new Package(LosAngeles.Code, 130));
            LosAngeles.Pickups.Add(new Package(NewYork.Code, 340));
            Miami.Pickups.Add(new Package(Guadalajara.Code, 1880));
            NewYork.Pickups.Add(new Package(Honolulu.Code, 330));
            Boise.Pickups.Add(new Package(Miami.Code, 230));

            CurrentAirport = Boise;
        }
        public Game()
        {
            Setup();
        }
    }
}