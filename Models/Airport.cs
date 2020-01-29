using System.Collections.Generic;

namespace FedUp.Models
{
    class Airport
    {
        public string Name { get; }
        public string Code { get; }
        public Dictionary<string, Airport> Destinations { get; set; }
        //list of packages

        //Method for adding airports
        public void AddDestination(Airport des)
        {
            Destinations.Add(des.Code, des);
            //Add this airport as destination to other 
            des.Destinations.Add(Code, this);
        }

        public Airport(string name, string code)
        {
            Name = name;
            Code = code;
            Destinations = new Dictionary<string, Airport>();
        }
    }
}