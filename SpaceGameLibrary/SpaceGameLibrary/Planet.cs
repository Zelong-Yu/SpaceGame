using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGameLibrary
{
    public class Planet
    {
        public Char Planets { get; set; }

        public void Quadrant()
        {
            Console.WriteLine("\t\t" + "  1 2 3 4 5 6 7 8 9 10");
            Console.WriteLine("\t\t" + " 1 * . . . . . . . . ." + "\t" +"Startdate");
            Console.WriteLine("\t\t" + " 2 . . . E . . . . . ." + "\t" +"Condition");
            Console.WriteLine("\t\t" + " 3 . . . . . . * . . ." + "\t" +"Position");
            Console.WriteLine("\t\t" + " 4 . . . . . . W . .* " + "\t" +"Life Support");
            Console.WriteLine("\t\t" + " 5 . . . . . * * . . . " + "\t" +"Warp Factor");
            Console.WriteLine("\t\t" + " 6 . * . . . . . . . ." + "\t" +"Energy");
            Console.WriteLine("\t\t" + " 7 . . . . . * * * . .");
            Console.WriteLine("\t\t" + " 8 . . . . B . . . . ." );
            Console.WriteLine("\t\t" + " 9 . * . . . . . . * ." + "\t" +"Shields");
            Console.WriteLine("\t\t" + "10 . . . . . . R . . ." + "\t" +"Time Left");
        }

        public void DisplayHeader()
        {
            Console.WriteLine("   /$$$$$$   /$$                               /$$$$$$$$                  /$$ ");
            Console.WriteLine("    /$$__  $$ | $$                              |__  $$__/                 | $$ ");
            Console.WriteLine("   | $$   __//$$$$$$    /$$$$$$   /$$$$$$          | $$  /$$$$$$   /$$$$$$ | $$   /$$");
            Console.WriteLine("   |  $$$$$$|_  $$_/   |____  $$ /$$__  $$         | $$ /$$__  $$ /$$__  $$| $$  /$$/");
            Console.WriteLine("    ____  $$ | $$      /$$$$$$$| $$   __/         | $$| $$   __/| $$$$$$$$| $$$$$$/");
            Console.WriteLine("   /$$    $$ | $$ /$$ /$$__  $$| $$               | $$| $$      | $$_____/| $$_  $$");
            Console.WriteLine("   |  $$$$$$/ |  $$$$/|  $$$$$$$| $$               | $$| $$      |  $$$$$$$| $$    $$");
            Console.WriteLine("     ______/    ___/    _______/|__/               |__/|__/        _______/|__/   __/");
            Console.WriteLine("   $$$$$$$$                        $$                  $$       $$                  ");
            Console.WriteLine("    $$ | $$$$$$   $$$$$$    $$$$$$$ | $$$$$$         $$ |$$$  $$ | $$$$$$    $$$$$$ ");
            Console.WriteLine("   $$ |$$  __$$   ____$$  $$  __$$ |$$  __$$        $$ $$ $$ $$ |  ____$$  $$  __$$");
            Console.WriteLine("   $$ |$$ |   __|$$$$$$$ |$$ /  $$ |$$$$$$$$ |      $$$$  _$$$$ | $$$$$$$ |$$ |   __|");
            Console.WriteLine("    $$ |$$ |     $$  __$$ |$$ |  $$ |$$   ____|      $$$  /  $$$ |$$  __$$ |$$ |");
            Console.WriteLine("    $$ |$$ |      $$$$$$$ | $$$$$$$ | $$$$$$$        $$  /    $$ | $$$$$$$ |$$ |");
            Console.WriteLine("    __ | __ |       _______ |  _______ |  _______ |       __ /      __ |  _______ | __ |");

        }
    }

}
