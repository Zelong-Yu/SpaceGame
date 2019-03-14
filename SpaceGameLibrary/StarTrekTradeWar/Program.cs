using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SpaceGameLibrary;

namespace StarTrekTradeWar
{
    class Program
    {
        static void Main(string[] args)
        {
            Test();
        }

        static void Test()
        {
            Utility forTest = new Utility();
            forTest.DisplayHeader();
            Console.ReadKey();
        }
    }
}
