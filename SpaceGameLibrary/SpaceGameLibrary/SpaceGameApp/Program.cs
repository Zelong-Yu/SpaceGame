using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceGameLibrary;

namespace SpaceGameApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Planet planet = new Planet();
            Console.WriteLine("\n\n");
            //Call DisplayHeader from Utility class
            Utility forTest = new Utility();
            forTest.DisplayHeader();
            Console.WriteLine("\n\n");

            //Display Quadrant method content
            planet.Quadrant();
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
