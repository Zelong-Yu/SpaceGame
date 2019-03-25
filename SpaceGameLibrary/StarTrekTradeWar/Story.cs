using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;
using Console = Colorful.Console;

namespace StarTrekTradeWar
{
    public static class Story
    {

    public static void DisplayHeader()
        {

            List<string> storyFragments = new List<string>();

            storyFragments.Add(@"  /$$$$$$   /$$                               /$$$$$$$$                  /$$         ");
            storyFragments.Add(@" /$$__  $$ | $$                              |__  $$__/                 | $$         ");
            storyFragments.Add(@"| $$  \__//$$$$$$    /$$$$$$   /$$$$$$          | $$  /$$$$$$   /$$$$$$ | $$   /$$   ");
            storyFragments.Add(@"|  $$$$$$|_  $$_/   |____  $$ /$$__  $$         | $$ /$$__  $$ /$$__  $$| $$  /$$/   ");
            storyFragments.Add(@" \____  $$ | $$      /$$$$$$$| $$  \__/         | $$| $$  \__/| $$$$$$$$| $$$$$$/    ");
            storyFragments.Add(@" /$$  \ $$ | $$ /$$ /$$__  $$| $$               | $$| $$      | $$_____/| $$_  $$    ");
            storyFragments.Add(@"|  $$$$$$/ |  $$$$/|  $$$$$$$| $$               | $$| $$      |  $$$$$$$| $$ \  $$   ");
            storyFragments.Add(@" \______/   \___/   \_______/|__/               |__/|__/       \_______/|__/  \__/  ");
            storyFragments.Add(@"$$$$$$$$\                       $$\                 $$\      $$\                     ");
            storyFragments.Add(@"\__$$  __|                      $$ |                $$ | $\  $$ |                    ");
            storyFragments.Add(@"   $$ | $$$$$$\  $$$$$$\   $$$$$$$ | $$$$$$\        $$ |$$$\ $$ | $$$$$$\   $$$$$$\  ");
            storyFragments.Add(@"   $$ |$$  __$$\ \____$$\ $$  __$$ |$$  __$$\       $$ $$ $$\$$ | \____$$\ $$  __$$\ ");
            storyFragments.Add(@"   $$ |$$ |  \__|$$$$$$$ |$$ /  $$ |$$$$$$$$ |      $$$$  _$$$$ | $$$$$$$ |$$ |  \__|");
            storyFragments.Add(@"   $$ |$$ |     $$  __$$ |$$ |  $$ |$$   ____|      $$$  / \$$$ |$$  __$$ |$$ |      ");
            storyFragments.Add(@"   $$ |$$ |     \$$$$$$$ |\$$$$$$$ |\$$$$$$$\       $$  /   \$$ |\$$$$$$$ |$$ |      ");
            storyFragments.Add(@"   \__|\__|      \_______| \_______| \_______|      \__/     \__| \_______|\__|      ");
            
            ColorGradientDisplay(storyFragments);
            Console.CursorVisible = false;
            PrintAsciiArt("Where No Man Has");
            PrintAsciiArt("Trade Before");
            Utility.PromptForInput("Press any key to Enter the War");
            Console.CursorVisible = true;

        }

        public static int factorial(int x) => x > 1 ? x * factorial(x - 1) : 1;
        public static int fact(int n)=> Enumerable.Range(1, n).Aggregate(1, (x, y) => x * y);

        public static int fibs(int x) => x <= 2 ? 1 : fibs(x - 1) + fibs(x - 2);

        public static int Fibo(int k) => Enumerable.Range(1, k).Skip(2).Aggregate(new { Current = 1, Prev = 0 },
                                  (x, index) => new { Current = x.Prev + x.Current, Prev = x.Current }).Current;



        public static void ClosingMessage(EndCondition e)
        {
            Console.Clear();
            switch (e)
            {
                case EndCondition.NotEnd:
                    break;
                case EndCondition.UserEnd:
                    PrintAsciiArt("See You Next Time");
                    break;
                case EndCondition.AgeOut:
                    UI.CenteredString("You're over 70 years old...time to retire, Captain");
                    break;
                case EndCondition.MoneyOut:
                    UI.CenteredString("You're out of money and out of goods. Starfleet Command is very disappointed.");
                    break;
                case EndCondition.FuelOut:
                    UI.CenteredString("Your stupidity has left you on your own drifting in the galaxy without fuel");
                    break;
                case EndCondition.Death:
                    UI.CenteredString("Death is inevitable");
                    break;
                case EndCondition.MoneyMax:
                    PrintAsciiArt("Mission Complete!");
                    PrintAsciiArt("$10,000 earned");
                    break;
                default:
                    break;
            }
        }

        public static void ColorGradientDisplay(List<string> storyFragments, int r=225, int g=255, int b=250, int rstep=10, int gstep=10, int bstep=5)
        {

            for (int i = 0; i < storyFragments.Count; i++)
            {
                Colorful.Console.WriteLine(storyFragments[i], Color.FromArgb(r, g, b));

                r -= rstep;
                b -= gstep;
                b -= bstep;
            }
        }

        private static void PrintAsciiArt(string s, int r = 205, int g=235, int b = 240)
        {

              Console.WriteAscii(s, Color.FromArgb(r, g, b));

        }
    }
}