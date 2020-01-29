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
            Messages.Add($"Balance: ${Game.AccountBalance}");
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
                Deliver();
                Pickup();

                Game.CurrentAirport = Game.CurrentAirport.Destinations[input];
                return;
            }
            Messages.Add("Invalid Input");
        }


        private void Deliver()
        {
            //check if any packages belong to the current airport 
            //remove them
            var total = 0;
            var delivered = Game.Deliveries.RemoveAll(p =>
            {
                if (p.DestinationCode == Game.CurrentAirport.Code)
                {
                    //collect pay
                    total += p.Value;
                    return true;
                }
                return false;
            });

            Messages.Add($"Delivered {delivered} packages.");
            Game.AccountBalance += total;
        }

        private void Pickup()
        {
            if (Game.CurrentAirport.Pickups.Count == 0)
            {
                Messages.Add("No packages at this location.");
                return;
            }
            Messages.Add($"Picking up {Game.CurrentAirport.Pickups.Count} packages.");
            Game.Deliveries.AddRange(Game.CurrentAirport.Pickups);
            Game.CurrentAirport.Pickups.Clear();
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