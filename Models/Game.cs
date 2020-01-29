namespace FedUp.Models
{
    class Game
    {
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

            Boise.Destinations.Add(Denver.Code, Denver);
        }
    }
}