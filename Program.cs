using System;
using FedUp.Controllers;

namespace FedUp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            GameController gc = new GameController();
            gc.Run();
        }
    }
}
