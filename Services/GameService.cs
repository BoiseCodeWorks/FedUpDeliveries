using System;
using System.Collections.Generic;
using System.Threading;
using FedUp.Models;

namespace FedUp.Services
{
    class GameService
    {
        private Game Game { get; set; } = new Game();
        public List<string> Messages { get; set; } = new List<string>();

        public void PrintMenu()
        {
            Messages.Add($"Welcome to {Game.CurrentAirport.Name}\n");
            Messages.Add("Destinations:");
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
                Console.Write("Flying");
                Timing(7);
                Console.Write("\nLanding");
                Timing(3);

                Console.Clear();

                Game.CurrentAirport = Game.CurrentAirport.Destinations[input];
                return;
            }
            Messages.Add("Invalid Input");
        }


        private void Deliver()
        {
            //check if any packages belong to the current airport 
            //remove them
            //collect pay
        }

        private void Pickup()
        {
            //check if current airport has pickups
            // transfer them into the game.deliveries
        }







        private static void Timing(int time)
        {
            for (int i = 0; i < time; i++)
            {
                Console.Write(".");
                Thread.Sleep(250);
            }
        }
    }
}