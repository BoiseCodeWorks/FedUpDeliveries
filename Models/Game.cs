namespace FedUp.Models
{
    class Game
    {
        public Airport CurrentAirport { get; set; }
        public void Setup()
        {
            //Create Data 
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

            // Create Relationships
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

            CurrentAirport = Boise;






        }
        public Game()
        {
            Setup();
        }
    }
}