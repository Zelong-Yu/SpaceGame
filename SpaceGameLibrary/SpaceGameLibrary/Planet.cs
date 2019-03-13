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
            Console.WriteLine("  1 2 3 4 5 6 7 8 9 10");
            Console.WriteLine(" 1 * . . . . . . . . ." + "\t" +"Startdate");
            Console.WriteLine(" 2 . . . E . . . . . ." + "\t" +"Condition");
            Console.WriteLine(" 3 . . . . . . * . . ." + "\t" +"Position");
            Console.WriteLine(" 4 . . . . . . W . .* " + "\t" +"Life Support");
            Console.WriteLine(" 5 . . . . . * * . . . " + "\t" +"Warp Factor");
            Console.WriteLine(" 6 . * . . . . . . . ." + "\t" +"Energy");
            Console.WriteLine(" 7 . . . . . * * * . .");
            Console.WriteLine(" 8 . . . . B . . . . ." );
            Console.WriteLine(" 9 . * . . . . . . * ." + "\t" +"Shields");
            Console.WriteLine("10 . . . . . . R . . ." + "\t" +"Time Left");
        }
    }

}
