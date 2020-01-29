using System;
using FedUp.Services;

namespace FedUp.Controllers
{
    class GameController
    {
        private GameService Service { get; set; } = new GameService();
        private bool _flying = true;

        public void Run()
        {
            Service.PrintMenu();
            while (_flying)
            {
                PrintMessages();
                GetUserInput();
            }
            Console.Clear();
            Console.WriteLine("Thanks for flying the friendly skies");
        }
        public void GetUserInput()
        {
            var input = Console.ReadLine().ToUpper();
            Console.Clear();
            switch (input)
            {
                case "Q":
                case "QUIT":
                case "EXIT":
                    _flying = false;
                    break;
                default:
                    System.Console.WriteLine("Invalid input");
                    Service.PrintMenu();
                    break;
            }

        }
        public void PrintMessages()
        {

        }
    }
}