using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarTrekTradeWar
{
    public static class UI
    {


        public static int SelectionMenu(List<string> optionslist, string title = "Options (Q to quit): ")
        {
            var done = false;

            int selector = 0;

            int count = optionslist.Count;

            do
            {
                Console.CursorVisible = false;
                var cursorLeftPos = Console.CursorLeft;
                var cursorTopPos = Console.CursorTop;
                Console.WriteLine(title);
                PrintMenu(selector, optionslist);
                var key = Utility.PromptForInput("");
                switch (key)
                {
                    case ConsoleKey.DownArrow:
                        selector++;
                        selector %= count;
                        break;
                    case ConsoleKey.UpArrow:
                        selector--;
                        selector = (selector + count) % count;
                        break;
                    case ConsoleKey.Q:
                        done = true;
                        selector = -1;
                        break;
                    case ConsoleKey.RightArrow:
                    case ConsoleKey.Enter:
                        done = true;
                        break;

                }
                //Console.CursorVisible = true;
                Console.SetCursorPosition(cursorLeftPos, cursorTopPos);
            } while (!done);
            return selector;
        }

        private static void PrintMenu(int selector, List<string> optionslist)
        {
            for (int i = 0; i < optionslist.Count; ++i)
            {
                Console.Write($"- ");
                if (i == selector)
                {
                    UI.Hightlight();

                }
                Console.WriteLine(optionslist[i]);
                Console.ResetColor();
            }
        }

        public static void Hightlight()
        {
            var background = Console.BackgroundColor;
            var foreground = Console.ForegroundColor;

            Console.ForegroundColor = background;
            Console.BackgroundColor = foreground;
        }

        //Print a string at the center of line
        public static void CenteredString(string s)
        {
            if (s.Length <= Console.WindowWidth)
            {
                Console.SetCursorPosition((Console.WindowWidth - s.Length) / 2, Console.CursorTop);
                Console.WriteLine(s);
            }
            else
            {
                throw new Exception("Oversided String");
            }
        }
    }
}