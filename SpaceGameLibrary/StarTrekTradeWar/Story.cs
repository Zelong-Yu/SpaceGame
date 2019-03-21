using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Colorful;

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
            System.Console.CursorVisible = false;
            PrintAsciiArt("Where No Man Has");
            PrintAsciiArt("Trade Before");
            Utility.PromptForInput("Press any key to Enter the War");
            System.Console.CursorVisible = true;
        }

        public static void ClosingMessage(EndCondition e)
        {
            System.Console.Clear();
            switch (e)
            {
                case EndCondition.NotEnd:
                    break;
                case EndCondition.UserEnd:
                    PrintAsciiArt("See You Next Time");
                    break;
                case EndCondition.AgeOut:
                    UI.CenteredString("You're 70 years old...");
                    break;
                case EndCondition.MoneyOut:
                    UI.CenteredString("You're broke");
                    break;
                case EndCondition.FuelOut:
                    UI.CenteredString("Your stupidity has left you on your own in the galaxy without fuel");
                    break;
                case EndCondition.Death:
                    UI.CenteredString("Death is inevitable");
                    break;
                default:
                    break;
            }
        }

        public static void ColorGradientDisplay(List<string> storyFragments, int r=225, int g=255, int b=250, int rstep=9, int gstep=9, int bstep=0)
        {

            for (int i = 0; i < storyFragments.Count; i++)
            {
                Colorful.Console.WriteLine(storyFragments[i], Color.FromArgb(r, g, b));

                r -= rstep;
                b -= gstep;
                b -= bstep;
            }
        }

        private static void PrintAsciiArt(string s)
        {
            int DA = 244;
            int V = 212;
            int ID = 255;
            for (int i = 0; i < 1; i++)
            {
                Colorful.Console.WriteAscii(s, Color.FromArgb(DA, V, ID));

                DA -= 8;
                V -= 6;
            }
        }
    }
}