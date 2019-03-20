using System;
using SpaceGameLibrary;

namespace SpaceGameApp
{
    public class App
    {
        Planet planet = new Planet();
        public App()
        {
        }

        public void Run()
        {
            Console.WriteLine("\n\n");
            //Call DisplayHeader from Utility class
            Utility forTest = new Utility();
            forTest.DisplayHeader();
            Console.WriteLine("\n\n");

            //Display Quadrant method content
            planet.Quadrant();
            Console.ReadKey();

            //Display Market
            Console.WriteLine("\n\n");
            Market market = new Market();
            Console.Write("\t\tEnter Market Name: ");
            market.MarketName = Console.ReadLine();
            Console.Write("\t\tEnter Market Currency: ");
            market.MarketCurrency = Console.ReadLine();
            Console.Write("\t\tEnter Your Inventories on Hand: ");
            market.GoodInventory = double.Parse( Console.ReadLine());

            market.DisplayMarket();
            Console.ReadKey();


            //display 2D Array
            Console.WriteLine("\n\n");
            Map map = new Map();
            map.DisplayMap();
            Console.WriteLine();
            Ship ship = new Ship(1, 2);
            map.Register(ship);
            map.DisplayMap();
            Console.WriteLine();
            ship.Move(5, 2,map);
            map.DisplayMap();
            Console.WriteLine();
            Star star = new Star(1, 2,5);
            map.Register(star);
            map.DisplayMap();

            ship.Move(1, 2, map);
            map.DisplayMap();
            Console.ReadKey();
        }
    }
}