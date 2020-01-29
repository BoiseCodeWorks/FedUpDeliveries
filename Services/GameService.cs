using System;
using System.Collections.Generic;
using System.Threading;
using FedUp.Models;

namespace FedUp.Services
{
    class GameService
    {
        private Game Game { get; set; } = new Game();
        public List<Message> Messages { get; set; } = new List<Message>();

        public void PrintMenu()
        {
            Messages.Add(new Message($"Balance: ${Game.AccountBalance}", ConsoleColor.Green));
            Messages.Add(new Message($"Welcome to {Game.CurrentAirport.Name}\n"));
            Messages.Add(new Message("Destinations:"));
            foreach (var des in Game.CurrentAirport.Destinations)
            {
                Messages.Add(new Message($"{des.Key} -- {des.Value.Name}"));
            }
            Messages.Add(new Message("Where to go?"));
        }

        internal void Travel(string input)
        {
            if (Game.CurrentAirport.Destinations.ContainsKey(input))
            {
                Messages.Add(new Message(@"       __|__
--@--@--(_)--@--@--", ConsoleColor.Blue));
                Console.Write("Flying");
                Timing(7);
                Console.Write("\nLanding");
                Timing(3);
                Console.Clear();
                Game.CurrentAirport = Game.CurrentAirport.Destinations[input];
                Deliver();
                Pickup();
                return;
            }
            Messages.Add(new Message("Invalid Input", ConsoleColor.Red, 1000, true));
        }

        internal void PrintCargo()
        {
            Messages.Add(new Message("------CARGO-------"));
            foreach (Package p in Game.Deliveries)
            {
                Messages.Add(new Message($"{p.DestinationCode} -- ${p.Value}"));
            }
            Messages.Add(new Message("press any key to return"));
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
            Messages.Add(new Message($"Delivered {delivered} packages."));
            Game.AccountBalance += total;
        }

        private void Pickup()
        {
            if (Game.CurrentAirport.Pickups.Count == 0)
            {
                Messages.Add(new Message("No packages at this location."));
                return;
            }
            Messages.Add(new Message($"Picking up {Game.CurrentAirport.Pickups.Count} packages."));
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