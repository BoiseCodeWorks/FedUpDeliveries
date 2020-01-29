using System;
using System.Collections.Generic;
using FedUp.Models;

namespace FedUp.Services
{
    class GameService
    {
        private Game Game { get; set; } = new Game();
        public List<string> Messages { get; set; } = new List<string>();

        public void PrintMenu()
        {
            Messages.Add($"Welcome to {Game.CurrentAirport.Name}");
            Messages.Add("Destinations");
            foreach (var des in Game.CurrentAirport.Destinations)
            {
                Messages.Add($"{des.Key} -- {des.Value.Name}");
            }
            Messages.Add("Where to go?");
        }

        internal void Travel(string input)
        {
            if (Game.CurrentAirport.Destinations.ContainsKey(input))
            {
                Game.CurrentAirport = Game.CurrentAirport.Destinations[input];
                return;
            }
            Messages.Add("Invalid Input");
        }
    }
}