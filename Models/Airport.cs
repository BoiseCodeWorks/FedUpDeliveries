using System.Collections.Generic;

namespace FedUp.Models
{
    class Airport
    {
        public string Name { get; }
        public string Code { get; }
        public Dictionary<string, Airport> Destinations { get; set; }
        //list of packages

        public Airport(string name, string code)
        {
            Name = name;
            Code = code;
            Destinations = new Dictionary<string, Airport>();
        }
    }
}